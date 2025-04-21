using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.Controllers
{
    public class HomeController : BaseController
    {
        [Route("en")]
        public IActionResult Index()
        {
            return View();
        }
    }
}