using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.User.ViewComponents
{
    public class UserDashboard : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("UserDashboard"));
        }
    }
}
