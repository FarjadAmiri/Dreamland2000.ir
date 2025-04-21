using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class Footer : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;
        private readonly IRealEstateService _realEstateService;

        public Footer(IContactService contactService, IAboutService aboutService, IUserService userService, IRealEstateService realEstateService)
        {
            _contactService = contactService;
            _aboutService = aboutService;
            _userService = userService;
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //real estate group list
            var realEstateGroupList = await _realEstateService.GetRealEstateGroupList(3);
            ViewBag.RealEstateGroupList = realEstateGroupList.ToList();

            //contact
            var contact = await _contactService.GetContact(3);
            ViewBag.Contact = contact;

            //about
            var about = await _aboutService.GetAbout(3);
            ViewBag.About = about;

            //permission 
            if (User.Identity!.IsAuthenticated)
            {
                //user 
                var userName = User.Identity.Name;
                var user = await _userService.GetCurrentUserByUserName(userName!);

                ViewBag.IsAdmin = false;
                //admin 
                if (await _userService.UserIsAdmin(user.Id))
                {
                    ViewBag.IsAdmin = true;
                }
            }

            return await Task.FromResult((IViewComponentResult)View("Footer"));
        }
    }
}
