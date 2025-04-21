using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Agent;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class AgentSendMessageForm3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            AgentSendMessageViewModelSpanish viewmodel = new AgentSendMessageViewModelSpanish()
            {
                AgentRefId = id,
            };

            return await Task.FromResult((IViewComponentResult)View("AgentSendMessageForm3Col", viewmodel));
        }
    }
}
