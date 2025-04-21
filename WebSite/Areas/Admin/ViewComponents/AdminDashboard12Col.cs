using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class AdminDashboard12Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("AdminDashboard12Col"));
        }
    }
}
