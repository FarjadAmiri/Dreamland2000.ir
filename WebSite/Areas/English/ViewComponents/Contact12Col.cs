using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class Contact12Col : ViewComponent
    {
        private readonly IContactService _contactService;

        public Contact12Col(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //contact 
            var contact = await _contactService.GetContact(2);

            return await Task.FromResult((IViewComponentResult)View("Contact12Col", contact));
        }
    }
}
