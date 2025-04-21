using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class HomeBanner : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("HomeBanner"));
        }
    }
}
