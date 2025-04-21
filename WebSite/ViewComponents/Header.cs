using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class Header : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IRealEstateService _realEstateService;
        private readonly IServiceItemService _serviceItemService;


        public Header(IUserService userService, IRealEstateService realEstateService, IServiceItemService serviceItemService)
        {
            _userService = userService;
            _realEstateService = realEstateService;
            _serviceItemService = serviceItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //real estate group list
            var realEstateGroupList = await _realEstateService.GetRealEstateGroupList(1);
            ViewBag.RealEstateGroupList = realEstateGroupList.ToList();
 
            //service group list
            var serviceGroupList = await _serviceItemService.GetServiceGroupList(1);
            ViewBag.ServiceGroupList = serviceGroupList.ToList();

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
            return await Task.FromResult((IViewComponentResult)View("Header"));
        }
    }
}
