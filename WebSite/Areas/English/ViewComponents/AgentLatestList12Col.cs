using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;

namespace WebSite.Areas.English.ViewComponents
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

	        var agentList = await _agentService.GetAgentLatestList(4,2);

            return await Task.FromResult((IViewComponentResult)View("AgentLatestList12Col", agentList));
        }
    }
}
