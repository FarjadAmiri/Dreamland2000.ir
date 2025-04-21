using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Contact;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class ContactSendMessageForm9Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ContactSendMessageViewModelSpanish viewmodel = new ContactSendMessageViewModelSpanish();

            return await Task.FromResult((IViewComponentResult)View("ContactSendMessageForm9Col", viewmodel));
        }
    }
}
