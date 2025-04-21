using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class About12Col : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public About12Col(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //about 
            var about = await _aboutService.GetAbout(3);

            return await Task.FromResult((IViewComponentResult)View("About12Col", about));
        }
    }
}
