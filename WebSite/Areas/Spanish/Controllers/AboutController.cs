using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("es/about")]
        public async Task<IActionResult> Index()
        {
            //about 
            var about = await _aboutService.GetAbout(3);

            ViewBag.Navbar = "About";

            return View(about);
        }

    }
}