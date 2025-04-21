using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        [Route("user")]
        public IActionResult Index()
        {
            return View();
        }
    }
}