using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class About9Col : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public About9Col(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //about 
            var about = await _aboutService.GetAbout(3);

            return await Task.FromResult((IViewComponentResult)View("About9Col", about));
        }
    }
}
