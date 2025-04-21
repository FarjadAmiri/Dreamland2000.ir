using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Agent;

namespace WebSite.Areas.English.ViewComponents
{
    public class AgentProfile3ColByAgentId : ViewComponent
    {
        private readonly IGenericRepository<Agent> _agentRepository;

        public AgentProfile3ColByAgentId(IGenericRepository<Agent> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

	        var agent = await _agentRepository.GetById(id);

            return await Task.FromResult((IViewComponentResult)View("AgentProfile3ColByAgentId", agent));
        }
    }
}
