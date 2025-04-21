using WebSite.Core.Utility;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    [PermissionChecker(1)] // a: admin panel
    [Area("Admin")]
    public class BaseController : Controller
    {
       
    }
}