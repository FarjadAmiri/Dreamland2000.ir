using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Utility;

namespace WebSite.Areas.User.Controllers
{
    [Area("User")]
    [Authorize()]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class BaseController : Controller
    {
       
    }
}