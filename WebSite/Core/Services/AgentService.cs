using WebSite.Core.ViewModel.Agent;
using WebSite.DataLayer.Entities.Agent;

namespace WebSite.Core.Services
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAgentList(int language = -1);
        Task<IEnumerable<Agent>> GetAgentLatestList(int take = 100,int language=-1);
        Task<bool> VisitPlusAgentByAgentId(int id);

        //comment

        Task<AgentCommentListViewModel> GetAgentCommentList(int page = 1);
        Task<IEnumerable<AgentComment>> GetAcceptedAgentCommentListByAgentId(int id);
        Task<IEnumerable<AgentComment>> GetNotAcceptedAgentCommentListByAgentId(int id);
        Task<IEnumerable<AgentComment>> GetNotAcceptedAgentCommentList();
    }

    public class AgentService : IAgentService
    {
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IGenericRepository<AgentComment> _agentCommentRepository;
        public AgentService(IGenericRepository<Agent> agentRepository, IGenericRepository<AgentComment> agentCommentRepository)
        {
            _agentRepository = agentRepository;
            _agentCommentRepository = agentCommentRepository;
        }



        public async Task<IEnumerable<Agent>> GetAgentList(int language = -1)
        {
            var agentList = await _agentRepository.Get(
                includes: "Language",
                orderBy: q => q.OrderBy(d => d.LanguageRefId).ThenBy(s=>s.Sort));

            //language filter
            if (language != -1)
            {
                agentList = agentList.Where(l => l.LanguageRefId == language);
            }

            return agentList;
        }

        public async Task<IEnumerable<Agent>> GetAgentLatestList(int take = 100, int language = -1)
        {
            var agentList = await _agentRepository.Get(
                includes: "Language",
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                agentList = agentList.Where(l => l.LanguageRefId == language);
            }

            return agentList.Take(take);

        }

      

        public async Task<bool> VisitPlusAgentByAgentId(int id)
        {
            var agent = await _agentRepository.GetById(id);
            if (agent.Visit == null || agent.Visit < 0)
            {
                agent.Visit = 0;
            }

            agent.Visit += 1;

            await _agentRepository.Update(agent);

            return true;
        }

        public async Task<AgentCommentListViewModel> GetAgentCommentList(int page = 1)
        {
            var commentList = await _agentCommentRepository.Get(
                includes: "User,Agent",
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            commentList = commentList.ToList();

            int take = 60;
            int skip = (page - 1) * take;
            AgentCommentListViewModel viewModel = new AgentCommentListViewModel()
            {
                CommentList = commentList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = commentList.Count() / take,
                TotalCount = commentList.Count(),
            };
            return viewModel;
        }

        public async Task<IEnumerable<AgentComment>> GetAcceptedAgentCommentListByAgentId(int id)
        {
            var agentCommentList = await _agentCommentRepository.Get(
                i => i.AgentRefId == id &&
                     i.IsAccept == true,
                includes: "User,Agent",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return agentCommentList;
        }

        public async Task<IEnumerable<AgentComment>> GetNotAcceptedAgentCommentListByAgentId(int id)
        {
            var agentCommentList = await _agentCommentRepository.Get(
                i => i.AgentRefId == id &&
                     i.IsAccept == false,
                includes: "User,Agent",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return agentCommentList;
        }

        public async Task<IEnumerable<AgentComment>> GetNotAcceptedAgentCommentList()
        {
            var commentList = await _agentCommentRepository.Get(
                i => i.IsAccept == false,
                includes: "User,Agent",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return commentList;
        }
    }
}
