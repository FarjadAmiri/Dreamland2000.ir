using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.RealEstate;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.English.Controllers
{    
    public class RealEstateController : BaseController
    {
        private readonly IGenericRepository<RealEstate> _realEstateRepository;
        private readonly IGenericRepository<RealEstateRentPeriod> _realEstateRentPeriodRepository;
        private readonly IGenericRepository<RealEstateUsageStatus> _realEstateUsageRepository;
        private readonly IGenericRepository<RealEstateBuildingDirection> _realEstateDirectionRepository;
        private readonly IGenericRepository<RealEstateComment> _realEstateCommentRepository;
        private readonly IGenericRepository<RealEstateType> _realEstateTypeRepository;
        private readonly IGenericRepository<RealEstateStatus> _realEstateStatusRepository;
        private readonly IGenericRepository<RealEstateGroup> _realEstateGroupRepository;
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IRealEstateService _realEstateService;
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;


        public RealEstateController(IGenericRepository<RealEstate> realEstateRepository, IGenericRepository<RealEstateComment> realEstateCommentRepository, IGenericRepository<RealEstateType> realEstateTypeRepository, IGenericRepository<RealEstateGroup> realEstateGroupRepository, ICaptchaValidator captchaValidator, IRealEstateService realEstateService, IUserService userService, IGenericRepository<RealEstateRentPeriod> realEstateRentPeriodRepository, IGenericRepository<Agent> agentRepository, IAddressService addressService, IGenericRepository<RealEstateUsageStatus> realEstateUsageRepository, IGenericRepository<RealEstateStatus> realEstateStatusRepository, IGenericRepository<RealEstateBuildingDirection> realEstateDirectionRepository)
        {
            _realEstateRepository = realEstateRepository;
            _realEstateCommentRepository = realEstateCommentRepository;
            _realEstateTypeRepository = realEstateTypeRepository;
            _realEstateGroupRepository = realEstateGroupRepository;
            _captchaValidator = captchaValidator;
            _realEstateService = realEstateService;
            _userService = userService;
            _realEstateRentPeriodRepository = realEstateRentPeriodRepository;
            _agentRepository = agentRepository;
            _addressService = addressService;
            _realEstateUsageRepository = realEstateUsageRepository;
            _realEstateStatusRepository = realEstateStatusRepository;
            _realEstateDirectionRepository = realEstateDirectionRepository;
        }

        [Route("en/realestate/grid")]
        public async Task<IActionResult> Grid(int page = 1, int group = -1,int type=-1,int city=-1, string search = "" )
        {
            var realEstateList = await _realEstateService.GetRealEstateList(page, group,type,city, search, 24,2);

            //photo list 
            foreach (var item in realEstateList.RealEstateList!)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            //filter
            ViewBag.GroupId = group;
            ViewBag.CityId = city;
            ViewBag.Search = search;


            ViewBag.Navbar = "RealEstate";

            return View(realEstateList);
        }

        [Route("en/realestate/list")]
        public async Task<IActionResult> List(int page = 1, int group = -1, int type = -1, int city = -1, string search = "")
        {
            var realEstateList = await _realEstateService.GetRealEstateList(page, group,type, city, search, 24,2);

            //photo list 
            foreach (var item in realEstateList.RealEstateList!)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            //filter
            ViewBag.GroupId = group;
            ViewBag.CityId = city;
            ViewBag.TypeId = type;
            ViewBag.Search = search;


            ViewBag.Navbar = "RealEstate";

            return View(realEstateList);
        }

        [Route("en/realestate/{id}")]
        public async Task<IActionResult> Details(int id) // id = realEstate id
        {
            //realEstate 
            var realEstate = await _realEstateRepository.GetById(id);

            //visit ++
            await _realEstateService.VisitPlusByRealEstateId(realEstate.Id);
          

            //group 
            if (realEstate.GroupRefId != null)
            {
                var group = await _realEstateGroupRepository.GetById(realEstate.GroupRefId.Value);
                realEstate.Group = group;
            }

            //type 
            if (realEstate.TypeRefId != null)
            {
                var type = await _realEstateTypeRepository.GetById(realEstate.TypeRefId!.Value);
                realEstate.Type = type;
            }

            //rent period 
            if (realEstate.RentPeriodRefId != null)
            {
                var rentPeriod = await _realEstateRentPeriodRepository.GetById(realEstate.RentPeriodRefId!.Value);
                realEstate.RentPeriod = rentPeriod;
            }

            //agent
            if (realEstate.AgentRefId != null)
            {
                var agent = await _agentRepository.GetById(realEstate.AgentRefId!.Value);
                realEstate.Agent = agent;
            }

            //usage
            if (realEstate.UsageRefId != null)
            {
                var usage = await _realEstateUsageRepository.GetById(realEstate.UsageRefId!.Value);
                realEstate.Usage = usage;
            }

            //status
            if (realEstate.StatusRefId != null)
            {
                var status = await _realEstateStatusRepository.GetById(realEstate.StatusRefId!.Value);
                realEstate.Status = status;
            }

            //direction
            if (realEstate.DirectionRefId != null)
            {
                var direction = await _realEstateDirectionRepository.GetById(realEstate.DirectionRefId!.Value);
                realEstate.Direction = direction;
            }

            //comment list
            var commentList = await _realEstateService.GetRealEstateCommentListByRealEstateId(realEstate.Id);
            realEstate.CommentList = commentList.ToList();

            //option list
            var optionList = await _realEstateService.GetOptionListByRealEstateId(realEstate.Id);
            realEstate.OptionList = optionList.ToList();

            //photo list
            var photoList = await _realEstateService.GetPhotoListByRealEstateId(realEstate.Id);
            realEstate.PhotoList = photoList.ToList();

            ViewBag.Navbar = "RealEstate";

            return View(realEstate);
        }


        [HttpPost("en/realestate/comment/send")]
        public async Task<IActionResult> SendComment(AddNewRealEstateCommentViewModelEnglish viewmodel)
        {
            //google recaptcha validation
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.RealEstateRefId });
            }


            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.RealEstateRefId });
            }

            //new comment
            RealEstateComment newComment = new RealEstateComment()
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Tell = viewmodel.Tell,
                Comment = viewmodel.Comment,
                RealEstateRefId = viewmodel.RealEstateRefId,
            };

            if (User.Identity!.IsAuthenticated)
            {
                //current user 
                var userName = User.Identity!.Name;
                var currentUser = await _userService.GetCurrentUserByUserName(userName!);
                newComment.UserRefId = currentUser.Id;
            }
            //save comment
            await _realEstateCommentRepository.Add(newComment);

            TempData["AlertMessage"] = AlertResource.CommentSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = newComment.RealEstateRefId });
        }

        //search 
        [HttpPost("en/realestate/search"), ValidateAntiForgeryToken]
        public IActionResult Search(RealEstateSearchViewModel viewmodel)
        {
            return RedirectToAction("Grid", new { search = viewmodel.SearchText });

        }
        
        //advance search 
        [Route("en/realestate/search/advance")]
        public async Task<IActionResult> AdvanceSearch()
        {
            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(2);

            //latest real estate
            var realEstateList = await _realEstateService.GetRealEstateLatestList(24,2);

            
            realEstateList = realEstateList.ToList();

            //photo list 
            foreach (var item in realEstateList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            RealEstateAdvanceSearchViewModelEnglish viewmodel = new RealEstateAdvanceSearchViewModelEnglish()
            {
                OptionList = optionList.ToList(),
                RealEstateList = realEstateList.ToList(),
            };
            
            //group 
            var groupList = await _realEstateService.GetRealEstateGroupList(2);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title");

            //city
            var cityList = await _addressService.GetCityList(2);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title");

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(2);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title");

            ViewBag.Navbar = "RealEstate";

            return View(viewmodel);
        }
       
        [HttpPost("en/realestate/search/advance"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AdvanceSearch(RealEstateAdvanceSearchViewModelEnglish viewmodel)
        {
            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(2);

            //group 
            var groupList = await _realEstateService.GetRealEstateGroupList(2);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title",viewmodel.GroupRefId);

            //city
            var cityList = await _addressService.GetCityList(2);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title",viewmodel.CityRefId);

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(2);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title", viewmodel.TypeRefId);

            var realEstateList = await _realEstateService.GetRealEstateList(2);
            

            //group filter
            if (viewmodel.GroupRefId != null)
            {
                realEstateList = realEstateList.Where(g => g.GroupRefId == viewmodel.GroupRefId);
            }

            //type filter
            if (viewmodel.TypeRefId != null)
            {
                realEstateList = realEstateList.Where(g => g.TypeRefId == viewmodel.TypeRefId);
            }

            //city filter
            if (viewmodel.CityRefId != null)
            {
                realEstateList = realEstateList.Where(g => g.CityRefId == viewmodel.CityRefId);
            }

            //room filter
            if (viewmodel.RoomCount != null)
            {
                realEstateList = realEstateList.Where(g => g.RoomCount == viewmodel.RoomCount);
            }

            //bathroom filter
            if (viewmodel.BathroomCount != null)
            {
                realEstateList = realEstateList.Where(g => g.BathroomCount == viewmodel.BathroomCount);
            }

            //parking filter
            if (viewmodel.ParkingCount != null)
            {
                realEstateList = realEstateList.Where(g => g.ParkingCount == viewmodel.ParkingCount);
            }

            //price filter
            if (viewmodel.MinPrice != null && viewmodel.MinPrice >0)
            {
                realEstateList = realEstateList.Where(g => g.Price >=viewmodel.MinPrice);
            }

            if (viewmodel.MaxPrice != null && viewmodel.MaxPrice > 0)
            {
                realEstateList = realEstateList.Where(g => g.Price <= viewmodel.MaxPrice);
            }

            //area filter
            if (viewmodel.MinArea != null && viewmodel.MinArea > 0)
            {
                realEstateList = realEstateList.Where(g => g.Area >= viewmodel.MinArea);
            }

            if (viewmodel.MaxArea != null && viewmodel.MaxArea > 0)
            {
                realEstateList = realEstateList.Where(g => g.Price <= viewmodel.MaxArea);
            }

            realEstateList = realEstateList.ToList();


            //photo list 
            foreach (var item in realEstateList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            viewmodel.RealEstateList = realEstateList.ToList();
            viewmodel.OptionList = optionList.ToList();

            ViewBag.Navbar = "RealEstate";

            return View(viewmodel);

        }

        [Route("en/realestate/comment/{id}")]
        public async Task<IActionResult> CommentList(int id) // id = realEstate id
        {
            //realEstate 
            var realEstate = await _realEstateRepository.GetById(id);

            //comment list
            var commentList = await _realEstateService.GetRealEstateCommentListByRealEstateId(realEstate.Id);
            realEstate.CommentList = commentList.ToList();

            ViewBag.Navbar = "RealEstate";

            return View(realEstate);
        }


    }
}