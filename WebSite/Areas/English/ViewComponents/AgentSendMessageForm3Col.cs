using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Agent;

namespace WebSite.Areas.English.ViewComponents
{
    public class AgentSendMessageForm3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            AgentSendMessageViewModelEnglish viewmodel = new AgentSendMessageViewModelEnglish()
            {
                AgentRefId = id,
            };

            return await Task.FromResult((IViewComponentResult)View("AgentSendMessageForm3Col", viewmodel));
        }
    }
}
