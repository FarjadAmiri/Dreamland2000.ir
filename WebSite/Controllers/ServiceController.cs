using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.Service;
using WebSite.DataLayer.Entities.Service;

namespace WebSite.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IGenericRepository<Service> _serviceRepository;
        private readonly IGenericRepository<ServiceComment> _serviceCommentRepository;
        private readonly IGenericRepository<ServiceGroup> _serviceGroupRepository;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IServiceItemService _serviceItemService;
        private readonly IUserService _userService;


        public ServiceController(IGenericRepository<Service> serviceRepository, IGenericRepository<ServiceGroup> serviceGroupRepository, ICaptchaValidator captchaValidator, IServiceItemService serviceItemService, IUserService userService, IGenericRepository<ServiceComment> serviceCommentRepository)
        {
            _serviceRepository = serviceRepository;
            _serviceGroupRepository = serviceGroupRepository;
            _captchaValidator = captchaValidator;
            _serviceItemService = serviceItemService;
            _userService = userService;
            _serviceCommentRepository = serviceCommentRepository;
        }

        [Route("service")]
        public async Task<IActionResult> Index(int group = -1)
        {
            var serviceList = await _serviceItemService.GetServiceList(group,1);

            //filter
            ViewBag.GroupId = group;

            ViewBag.Navbar = "Service";

            return View(serviceList);
        }

        [Route("service/category")]
        public async Task<IActionResult> Category()
        {
            var serviceGroupList = await _serviceItemService.GetServiceGroupList(1);
            
            ViewBag.Navbar = "Service";

            return View(serviceGroupList);
        }

        [Route("service/{id}")]
        public async Task<IActionResult> Details(int id) // id = service id
        {
            //service 
            var service = await _serviceRepository.GetById(id);

            //visit ++
            await _serviceItemService.VisitPlusServiceByServiceId(service.Id);

            //group 
            if (service.GroupRefId != null)
            {
                var group = await _serviceGroupRepository.GetById(service.GroupRefId.Value);
                service.Group = group;
            }

            //comment list
            var commentList = await _serviceItemService.GetCommentListByServiceId(service.Id);
            service.CommentList = commentList.ToList();


            ViewBag.Navbar = "Service";

            return View(service);
        }

        [HttpPost("service/comment/send")]
        public async Task<IActionResult> SendComment(AddNewServiceCommentViewModel viewmodel)
        {
            //google recaptcha validation
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.ServiceRefId });
            }
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.ServiceRefId });
            }

            //new comment
            ServiceComment newComment = new ServiceComment()
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Tell = viewmodel.Tell,
                Comment = viewmodel.Comment,
                ServiceRefId = viewmodel.ServiceRefId,
            };

            if (User.Identity!.IsAuthenticated)
            {
                //current user 
                var userName = User.Identity!.Name;
                var currentUser = await _userService.GetCurrentUserByUserName(userName!);
                newComment.UserRefId = currentUser.Id;
            }
            //save comment
            await _serviceCommentRepository.Add(newComment);

            TempData["AlertMessage"] = AlertResource.CommentSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = newComment.ServiceRefId });
        }
    }
}