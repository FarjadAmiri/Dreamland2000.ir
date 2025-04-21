using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.Controllers
{
    public class HomeController : BaseController
    {
        [Route("es")]
        public IActionResult Index()
        {
            return View();
        }
    }
}