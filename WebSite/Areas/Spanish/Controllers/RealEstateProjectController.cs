using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.RealEstate;
using WebSite.DataLayer.Entities.Address;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.Language;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Spanish.Controllers
{    
    public class RealEstateProjectController : BaseController
    {
        private readonly IGenericRepository<RealEstateProject> _projectRepository;
        private readonly IGenericRepository<RealEstateProjectStatus> _projectStatusRepository;
        private readonly IGenericRepository<RealEstateProjectComment> _projectCommentRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IRealEstateService _realEstateService;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;


        public RealEstateProjectController(IGenericRepository<RealEstateProject> projectRepository, IGenericRepository<RealEstateProjectComment> projectCommentRepository, IGenericRepository<Agent> agentRepository, ICaptchaValidator captchaValidator, IRealEstateService realEstateService, IAddressService addressService, IUserService userService, IGenericRepository<RealEstateProjectStatus> projectStatusRepository, IGenericRepository<City> cityRepository, IGenericRepository<Language> languageRepository)
        {
            _projectRepository = projectRepository;
            _projectCommentRepository = projectCommentRepository;
            _agentRepository = agentRepository;
            _captchaValidator = captchaValidator;
            _realEstateService = realEstateService;
            _addressService = addressService;
            _userService = userService;
            _projectStatusRepository = projectStatusRepository;
            _cityRepository = cityRepository;
            _languageRepository = languageRepository;
        }

        [Route("es/realestate/project/project/grid")]
        public async Task<IActionResult> Grid(int page = 1, int city=-1, string search = "" )
        {
            var projectList = await _realEstateService.GetProjectList(page, city, search, 24,3);

            //photo list 
            foreach (var item in projectList.ProjectList!)
            {
                var photoList = await _realEstateService.GetPhotoListByProjectId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            //filter
            ViewBag.CityId = city;
            ViewBag.Search = search;


            ViewBag.Navbar = "Project";

            return View(projectList);
        }

        [Route("es/realestate/project/project/list")]
        public async Task<IActionResult> List(int page = 1, int city = -1, string search = "")
        {
            var projectList = await _realEstateService.GetProjectList(page,  city, search, 24,3);

            //photo list 
            foreach (var item in projectList.ProjectList!)
            {
                var photoList = await _realEstateService.GetPhotoListByProjectId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            //filter
            ViewBag.CityId = city;
            ViewBag.Search = search;


            ViewBag.Navbar = "Project";

            return View(projectList);
        }

        [Route("es/realestate/project/{id}")]
        public async Task<IActionResult> Details(int id) // id = project id
        {
            //project 
            var project = await _projectRepository.GetById(id);

            //visit ++
            await _realEstateService.VisitPlusByProjectId(project.Id);

            //agent 
            if (project.AgentRefId != null)
            {
                var agent = await _agentRepository.GetById(project.AgentRefId!.Value);
                project.Agent = agent;
            }

            //city 
            if (project.CityRefId != null)
            {
                var city = await _cityRepository.GetById(project.CityRefId!.Value);
                project.City = city;
            }

            //status 
            if (project.StatusRefId != null)
            {
                var status = await _projectStatusRepository.GetById(project.StatusRefId!.Value);
                project.Status = status;
            }

            //language 
            if (project.LanguageRefId != null)
            {
                var language = await _languageRepository.GetById(project.LanguageRefId!.Value);
                project.Language = language;
            }

            //comment list
            var commentList = await _realEstateService.GeCommentListByProjectId(project.Id);
            project.CommentList = commentList.ToList();

            //photo list
            var photoList = await _realEstateService.GetPhotoListByProjectId(project.Id);
            project.PhotoList = photoList.ToList();

            ViewBag.Navbar = "Project";

            return View(project);
        }


        [HttpPost("es/realestate/project/comment/send")]
        public async Task<IActionResult> SendComment(AddNewRealEstateProjectCommentViewModel viewmodel)
        {
            //google recaptcha validation
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.ProjectRefId });
            }

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.ProjectRefId });
            }

            //new comment
            RealEstateProjectComment newComment = new RealEstateProjectComment()
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Tell = viewmodel.Tell,
                Comment = viewmodel.Comment,
                ProjectRefId = viewmodel.ProjectRefId,
            };

            if (User.Identity!.IsAuthenticated)
            {
                //current user 
                var userName = User.Identity!.Name;
                var currentUser = await _userService.GetCurrentUserByUserName(userName!);
                newComment.UserRefId = currentUser.Id;
            }
            //save comment
            await _projectCommentRepository.Add(newComment);

            TempData["AlertMessage"] = AlertResource.CommentSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = newComment.ProjectRefId });
        }

        //search 
        [HttpPost("es/realestate/project/search"), ValidateAntiForgeryToken]
        public IActionResult Search(RealEstateSearchViewModel viewmodel)
        {
            return RedirectToAction("Grid", new { search = viewmodel.SearchText });

        }
        
        //advance search 
        [Route("es/realestate/project/search/advance")]
        public async Task<IActionResult> AdvanceSearch()
        {
            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(3);

            //latest real estate
            var projectList = await _realEstateService.GetRealEstateLatestList(24,3);

            projectList = projectList.ToList();
            //photo list 
            foreach (var item in projectList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            RealEstateAdvanceSearchViewModel viewmodel = new RealEstateAdvanceSearchViewModel()
            {
                OptionList = optionList.ToList(),
                RealEstateList = projectList.ToList(),
            };
            
            //group 
            var groupList = await _realEstateService.GetRealEstateGroupList(3);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title");

            //city
            var cityList = await _addressService.GetCityList(1);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title");

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(3);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title");

            ViewBag.Navbar = "Project";

            return View(viewmodel);
        }
       
        [HttpPost("es/realestate/project/search/advance"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AdvanceSearch(RealEstateAdvanceSearchViewModel viewmodel)
        {
            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(3);

            //group 
            var groupList = await _realEstateService.GetRealEstateGroupList(3);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title",viewmodel.GroupRefId);

            //city
            var cityList = await _addressService.GetCityList(1);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title",viewmodel.CityRefId);

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(3);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title", viewmodel.TypeRefId);

            var projectList = await _realEstateService.GetRealEstateList(3);
            

            //group filter
            if (viewmodel.GroupRefId != null)
            {
                projectList = projectList.Where(g => g.GroupRefId == viewmodel.GroupRefId);
            }

            //type filter
            if (viewmodel.TypeRefId != null)
            {
                projectList = projectList.Where(g => g.TypeRefId == viewmodel.TypeRefId);
            }

            //city filter
            if (viewmodel.CityRefId != null)
            {
                projectList = projectList.Where(g => g.CityRefId == viewmodel.CityRefId);
            }

            //room filter
            if (viewmodel.RoomCount != null)
            {
                projectList = projectList.Where(g => g.RoomCount == viewmodel.RoomCount);
            }

            //bathroom filter
            if (viewmodel.BathroomCount != null)
            {
                projectList = projectList.Where(g => g.BathroomCount == viewmodel.BathroomCount);
            }

            //parking filter
            if (viewmodel.ParkingCount != null)
            {
                projectList = projectList.Where(g => g.ParkingCount == viewmodel.ParkingCount);
            }

            //price filter
            if (viewmodel.MinPrice != null && viewmodel.MinPrice >0)
            {
                projectList = projectList.Where(g => g.Price >=viewmodel.MinPrice);
            }

            if (viewmodel.MaxPrice != null && viewmodel.MaxPrice > 0)
            {
                projectList = projectList.Where(g => g.Price <= viewmodel.MaxPrice);
            }

            //area filter
            if (viewmodel.MinArea != null && viewmodel.MinArea > 0)
            {
                projectList = projectList.Where(g => g.Area >= viewmodel.MinArea);
            }

            if (viewmodel.MaxArea != null && viewmodel.MaxArea > 0)
            {
                projectList = projectList.Where(g => g.Price <= viewmodel.MaxArea);
            }

            projectList = projectList.ToList();


            //photo list 
            foreach (var item in projectList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            viewmodel.RealEstateList = projectList.ToList();
            viewmodel.OptionList = optionList.ToList();

            ViewBag.Navbar = "Project";

            return View(viewmodel);

        }

        [Route("es/realestate/project/comment/{id}")]
        public async Task<IActionResult> CommentList(int id) // id = project id
        {
            //project 
            var project = await _projectRepository.GetById(id);

            //comment list
            var commentList = await _realEstateService.GeCommentListByProjectId(project.Id);
            project.CommentList = commentList.ToList();

            ViewBag.Navbar = "Project";

            return View(project);
        }


    }
}