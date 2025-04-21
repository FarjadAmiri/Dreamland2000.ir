using WebSite.DataLayer.Entities.Agent;

namespace WebSite.Core.ViewModel.Agent
{
    public class AgentCommentListViewModel
    {
        public List<AgentComment>? CommentList { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }
}
