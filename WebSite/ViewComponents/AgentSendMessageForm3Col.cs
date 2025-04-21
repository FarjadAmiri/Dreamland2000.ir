using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Agent;

namespace WebSite.ViewComponents
{
    public class AgentSendMessageForm3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            AgentSendMessageViewModel viewmodel = new AgentSendMessageViewModel()
            {
                AgentRefId = id,
            };

            return await Task.FromResult((IViewComponentResult)View("AgentSendMessageForm3Col", viewmodel));
        }
    }
}
