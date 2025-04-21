using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        [Route("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}