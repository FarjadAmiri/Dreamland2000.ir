using System.Text;
using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Global;


namespace WebSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISiteMapService _siteMapService;
        private readonly IAboutService _aboutService;


        public HomeController(ISiteMapService siteMapService, IAboutService aboutService)
        {
            _siteMapService = siteMapService;
            _aboutService = aboutService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Navbar = "Home";

            return View();
        }

        [HttpPost("global/search"), ValidateAntiForgeryToken]
        public IActionResult Search(GlobalSearchViewModel viewmodel)
        {
            ViewBag.Navbar = "Home";

            //job
            if (viewmodel.SearchType == 2)
            {
                return RedirectToAction("Grid", "Job", new { search = viewmodel.SearchText });
            }

            //ads
            if (viewmodel.SearchType == 2)
            {
                return RedirectToAction("Index", "Ads", new { search = viewmodel.SearchText });
            }

            //news
            if (viewmodel.SearchType == 3)
            {
                return RedirectToAction("Grid", "News", new { search = viewmodel.SearchText });
            }

            //store
            if (viewmodel.SearchType == 4)
            {
                return RedirectToAction("Grid", "Store", new { search = viewmodel.SearchText });
            }

            return RedirectToAction("Index");

        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }
        
        [Route("/construction")]
        public IActionResult Construction()
        {
            return View();
        }


        [Route("/sitemap.xml")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult> SiteMap()
        {
            string xml = await _siteMapService.GetSiteMap();
            return Content(xml, "text/xml");
        }

        [Route("robots.txt", Name = "GetRobotsText")]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("allow: /*");
            stringBuilder.AppendLine("disallow: /error");
            stringBuilder.AppendLine("disallow: /scrap");
            stringBuilder.AppendLine("disallow: /login");
            stringBuilder.AppendLine("disallow: /register");
            stringBuilder.AppendLine("disallow: /forgot");
            stringBuilder.AppendLine("disallow: /admin");
            stringBuilder.AppendLine("disallow: /user");

            return Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }
    }
}