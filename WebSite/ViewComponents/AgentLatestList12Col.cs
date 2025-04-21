using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;

namespace WebSite.ViewComponents
{
    public class AgentLatestList12Col : ViewComponent
    {
        private readonly IAgentService _agentService;

        public AgentLatestList12Col(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var agentList = await _agentService.GetAgentLatestList(3,1);

            return await Task.FromResult((IViewComponentResult)View("AgentLatestList12Col", agentList));
        }
    }
}
