using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class Contact3Col : ViewComponent
    {
        private readonly IContactService _contactService;

        public Contact3Col(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //contact 
            var contact = await _contactService.GetContact(1);

            return await Task.FromResult((IViewComponentResult)View("Contact3Col", contact));
        }
    }
}
