using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Contact;

namespace WebSite.ViewComponents
{
    public class ContactSendMessageForm9Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ContactSendMessageViewModel viewmodel = new ContactSendMessageViewModel();

            return await Task.FromResult((IViewComponentResult)View("ContactSendMessageForm9Col", viewmodel));
        }
    }
}
