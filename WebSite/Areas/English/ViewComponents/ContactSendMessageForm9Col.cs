using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Contact;

namespace WebSite.Areas.English.ViewComponents
{
    public class ContactSendMessageForm9Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ContactSendMessageViewModelEnglish viewmodel = new ContactSendMessageViewModelEnglish();

            return await Task.FromResult((IViewComponentResult)View("ContactSendMessageForm9Col", viewmodel));
        }
    }
}
