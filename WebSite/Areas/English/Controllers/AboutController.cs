using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("en/about")]
        public async Task<IActionResult> Index()
        {
            //about 
            var about = await _aboutService.GetAbout(2);

            ViewBag.Navbar = "About";

            return View(about);
        }

    }
}