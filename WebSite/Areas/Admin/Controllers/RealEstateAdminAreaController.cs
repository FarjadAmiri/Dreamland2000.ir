using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml;
using WebSite.Core.Services;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.RealEstate;
using WebSite.DataLayer.Entities.Address;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.Blog;
using WebSite.DataLayer.Entities.Language;
using WebSite.DataLayer.Entities.RealEstate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Language = WebSite.DataLayer.Entities.Language.Language;

namespace WebSite.Areas.Admin.Controllers
{
    public class RealEstateAdminAreaController : BaseController
    {
        private readonly IGenericRepository<RealEstate> _realEstateRepository;
        private readonly IGenericRepository<RealEstatePhoto> _realEstatePhotoRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<RealEstateJoinOption> _realEstateJoinOptionRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IGenericRepository<RealEstateType> _realEstateTypeRepository;
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IGenericRepository<RealEstateGroup> _groupRepository;
        private readonly IRealEstateService _realEstateService;
        private readonly IUploadService _uploadService;
        private readonly IAddressService _addressService;
        private readonly IAgentService _agentService;

        public RealEstateAdminAreaController(IGenericRepository<RealEstate> realEstateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Language> languageRepository, IGenericRepository<RealEstateType> realEstateTypeRepository, IGenericRepository<Agent> agentRepository, IGenericRepository<RealEstateGroup> groupRepository, IRealEstateService realEstateService, IUploadService uploadService, IAddressService addressService, IAgentService agentService, IGenericRepository<RealEstatePhoto> realEstatePhotoRepository, IGenericRepository<RealEstateJoinOption> realEstateJoinOptionRepository)
        {
            _realEstateRepository = realEstateRepository;
            _cityRepository = cityRepository;
            _languageRepository = languageRepository;
            _realEstateTypeRepository = realEstateTypeRepository;
            _agentRepository = agentRepository;
            _groupRepository = groupRepository;
            _realEstateService = realEstateService;
            _uploadService = uploadService;
            _addressService = addressService;
            _agentService = agentService;
            _realEstatePhotoRepository = realEstatePhotoRepository;
            _realEstateJoinOptionRepository = realEstateJoinOptionRepository;
        }

        [Route("admin/realestate/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var realEstateList = await _realEstateService.GetRealEstateList(page, 100);

            return View(realEstateList);
        }

        [Route("admin/realestate/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = realEstate id
        {
            //real estate 
            var realEstate = await _realEstateRepository.GetById(id);

            //group 
            if (realEstate.GroupRefId != null)
            {
                var group = await _groupRepository.GetById(realEstate.GroupRefId!.Value);
                realEstate.Group = group;
            }

            //agent 
            if (realEstate.AgentRefId != null)
            {
                var agent = await _agentRepository.GetById(realEstate.AgentRefId!.Value);
                realEstate.Agent = agent;
            }

            //type 
            if (realEstate.TypeRefId != null)
            {
                var type = await _realEstateTypeRepository.GetById(realEstate.TypeRefId!.Value);
                realEstate.Type = type;
            }

            //city 
            if (realEstate.CityRefId != null)
            {
                var city = await _cityRepository.GetById(realEstate.CityRefId!.Value);
                realEstate.City = city;
            }

            //language 
            if (realEstate.LanguageRefId != null)
            {
                var language = await _languageRepository.GetById(realEstate.LanguageRefId!.Value);
                realEstate.Language = language;
            }

            return View(realEstate);
        }

        [Route("admin/realestate/new")]
        public async Task<IActionResult> Create(int language)
        {
            //group
            var groupList = await _realEstateService.GetRealEstateGroupList(language);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title");

            //city
            var cityList = await _addressService.GetCityList(language);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title");

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(language);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title");

            //agent
            var agentList = await _agentService.GetAgentList(language);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name");

            //rent period
            var rentPeriodList = await _realEstateService.GetRentPeriodList(language);
            ViewBag.RentPeriodRefId = new SelectList(rentPeriodList,
                "Id", "Title");

            //status
            var statusList = await _realEstateService.GetRealEstateStatusList(language);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title");

            //usage
            var usageList = await _realEstateService.GetRealEstateUsageList(language);
            ViewBag.UsageRefId = new SelectList(usageList,
                "Id", "Title");

            //direction
            var directionList = await _realEstateService.GetRealEstateDirectionList(language);
            ViewBag.DirectionRefId = new SelectList(directionList,
                "Id", "Title");

            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(language);
            ViewBag.OptionList = optionList;

            //language
            var lang = await _languageRepository.GetById(language);

            AddNewRealEstateByAdminViewModel viewmodel = new AddNewRealEstateByAdminViewModel()
            {
                LanguageRefId = language,
                Tags = "Dreamland2000,Real estate,",
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/realestate/new"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewRealEstateByAdminViewModel viewmodel, List<int> selectedOption, List<IFormFile> uploadPhotos)
        {
            //group
            var groupList = await _realEstateService.GetRealEstateGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title", viewmodel.GroupRefId);
            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId!.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title", viewmodel.CityRefId);

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(viewmodel.LanguageRefId!.Value);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title", viewmodel.TypeRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId!.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //rent period
            var rentPeriodList = await _realEstateService.GetRentPeriodList(viewmodel.LanguageRefId!.Value);
            ViewBag.RentPeriodRefId = new SelectList(rentPeriodList,
                "Id", "Title", viewmodel.RentPeriodRefId);

            //status
            var statusList = await _realEstateService.GetRealEstateStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            //usage
            var usageList = await _realEstateService.GetRealEstateUsageList(viewmodel.LanguageRefId!.Value);
            ViewBag.UsageRefId = new SelectList(usageList,
                "Id", "Title", viewmodel.UsageRefId);

            //direction
            var directionList = await _realEstateService.GetRealEstateDirectionList(viewmodel.LanguageRefId!.Value);
            ViewBag.DirectionRefId = new SelectList(directionList,
                "Id", "Title", viewmodel.DirectionRefId);

            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(viewmodel.LanguageRefId!.Value);
            ViewBag.OptionList = optionList;


            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //new property
            RealEstate property = new RealEstate()
            {
                Title = viewmodel.Title,
                Code = viewmodel.Code,
                CityRefId = viewmodel.CityRefId,
                TypeRefId = viewmodel.TypeRefId,
                GroupRefId = viewmodel.GroupRefId,
                StatusRefId = viewmodel.StatusRefId,
                UsageRefId = viewmodel.UsageRefId,
                Summary = viewmodel.Summary,
                RoomCount = viewmodel.RoomCount,
                BathroomCount = viewmodel.BathroomCount,
                ParkingCount = viewmodel.ParkingCount,
                Tags = viewmodel.Tags,
                LanguageRefId = viewmodel.LanguageRefId,
                Area = viewmodel.Area,
                BaseArea = viewmodel.BaseArea,
                LandArea = viewmodel.LandArea,
                TerraceArea = viewmodel.TerraceArea,
                YardArea = viewmodel.YardArea,
                DirectionRefId = viewmodel.DirectionRefId,
                Location = viewmodel.Location,
                Price = viewmodel.Price,
                RentPeriodRefId = viewmodel.RentPeriodRefId,
                AgentRefId = viewmodel.AgentRefId,
                BuildYear = viewmodel.BuildYear,
                CoolingSystem = viewmodel.CoolingSystem,
                HeatingSystem = viewmodel.HeatingSystem,
                EnergyGrade = viewmodel.EnergyGrade,
                Floor = viewmodel.Floor,
                Unit = viewmodel.Unit,
                GarbageCost = viewmodel.GarbageCost,
                UnitCharge = viewmodel.UnitCharge,
            };

            //save
            await _realEstateRepository.Add(property);


            //option
            foreach (int opt in selectedOption)
            {
                RealEstateJoinOption join = new RealEstateJoinOption()
                {
                    OptionRefId = opt,
                    RealEstateRefId = property.Id
                };
                await _realEstateJoinOptionRepository.Add(join);
            }

            int i = 0;
            //upload photo list
            foreach (IFormFile item in uploadPhotos)
            {
                i++;
                if (MyFile.IsImage(item))
                {
                    RealEstatePhoto newPhoto = new RealEstatePhoto()
                    {
                        RealEstateRefId = property.Id,
                        Title = viewmodel.Title,
                        Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate"),
                        Sort = i,
                    };

                    await _realEstatePhotoRepository.Add(newPhoto);

                    //update main photo
                    if (property.Photo == "default.jpg")
                    {
                        property.Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate");
                        await _realEstateRepository.Update(property);
                    }
                }
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            var photoList = await _realEstateService.GetPhotoListByRealEstateId(property.Id);
            if (photoList.Any())
            {
                return RedirectToAction("UpdatePhotoList", new { id = property.Id });
            }
            return RedirectToAction("Details", "RealEstateAdminArea", new { id = property.Id });
        }

        //update post 
        [Route("admin/realestate/update/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            //property
            var property = await _realEstateRepository.GetById(id);

            //language
            var lang = await _languageRepository.GetById(property.LanguageRefId!.Value);

            UpdateRealEstateByAdminViewModel viewmodel = new UpdateRealEstateByAdminViewModel()
            {
                Title = property.Title,
                Code = property.Code,
                Summary = property.Summary,
                RoomCount = property.RoomCount,
                BathroomCount = property.BathroomCount,
                ParkingCount = property.ParkingCount,
                TypeRefId = property.TypeRefId,
                GroupRefId = property.GroupRefId,
                AgentRefId = property.AgentRefId,
                StatusRefId= property.StatusRefId,
                UsageRefId= property.UsageRefId,
                DirectionRefId = property.DirectionRefId,
                CityRefId = property.CityRefId,
                RealEstateRefId = property.Id,
                Photo = property.Photo,
                Tags = property.Tags,
                Area = property.Area,
                BaseArea= property.BaseArea,
                YardArea= property.YardArea,
                TerraceArea= property.TerraceArea,
                LandArea= property.LandArea,
                Location = property.Location,
                Price = property.Price,
                GarbageCost = property.GarbageCost,
                UnitCharge= property.UnitCharge,
                RentPeriodRefId = property.RentPeriodRefId,
                HeatingSystem= property.HeatingSystem,
                CoolingSystem= property.CoolingSystem,
                Floor= property.Floor,
                Unit= property.Unit,
                EnergyGrade= property.EnergyGrade,
                BuildYear= property.BuildYear,
                
                LanguageRefId = property.LanguageRefId,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            //group
            var groupList = await _realEstateService.GetRealEstateGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title", viewmodel.GroupRefId);
            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId!.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title", viewmodel.CityRefId);

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(viewmodel.LanguageRefId!.Value);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title", viewmodel.TypeRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId!.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //rent period
            var rentPeriodList = await _realEstateService.GetRentPeriodList(viewmodel.LanguageRefId!.Value);
            ViewBag.RentPeriodRefId = new SelectList(rentPeriodList,
                "Id", "Title", viewmodel.RentPeriodRefId);

            //status
            var statusList = await _realEstateService.GetRealEstateStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            //usage
            var usageList = await _realEstateService.GetRealEstateUsageList(viewmodel.LanguageRefId!.Value);
            ViewBag.UsageRefId = new SelectList(usageList,
                "Id", "Title", viewmodel.UsageRefId);

            //direction
            var directionList = await _realEstateService.GetRealEstateDirectionList(viewmodel.LanguageRefId!.Value);
            ViewBag.DirectionRefId = new SelectList(directionList,
                "Id", "Title", viewmodel.DirectionRefId);

            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(viewmodel.LanguageRefId!.Value);
            ViewBag.OptionList = optionList;

            var selectedOptionList = await _realEstateService.GetOptionListByRealEstateId(property.Id);
            ViewBag.SelectedOptionList = selectedOptionList;


            return View(viewmodel);
        }

        [HttpPost("admin/realestate/update/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateRealEstateByAdminViewModel viewmodel, List<int> selectedOption, IFormFile? uploadPhoto)
        {
            //group
            var groupList = await _realEstateService.GetRealEstateGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title", viewmodel.GroupRefId);

            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title", viewmodel.CityRefId);

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(viewmodel.LanguageRefId.Value);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title", viewmodel.TypeRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //rent period
            var rentPeriodList = await _realEstateService.GetRentPeriodList(viewmodel.LanguageRefId.Value);
            ViewBag.RentPeriodRefId = new SelectList(rentPeriodList,
                "Id", "Title", viewmodel.RentPeriodRefId);

            //status
            var statusList = await _realEstateService.GetRealEstateStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            //usage
            var usageList = await _realEstateService.GetRealEstateUsageList(viewmodel.LanguageRefId!.Value);
            ViewBag.UsageRefId = new SelectList(usageList,
                "Id", "Title", viewmodel.UsageRefId);

            //direction
            var directionList = await _realEstateService.GetRealEstateDirectionList(viewmodel.LanguageRefId!.Value);
            ViewBag.DirectionRefId = new SelectList(directionList,
                "Id", "Title", viewmodel.DirectionRefId);

            //option
            var optionList = await _realEstateService.GetRealEstateOptionList(viewmodel.LanguageRefId!.Value);
            ViewBag.OptionList = optionList;

            var selectedOptionList = await _realEstateService.GetOptionListByRealEstateId(viewmodel.RealEstateRefId!.Value);
            ViewBag.SelectedOptionList = selectedOptionList;

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //property
            var property = await _realEstateRepository.GetById(viewmodel.RealEstateRefId!.Value);

            //update realEstate
            property.Title = viewmodel.Title;
            property.Code = viewmodel.Code;
            property.Price = viewmodel.Price;
            property.GarbageCost= viewmodel.GarbageCost;
            property.UnitCharge= viewmodel.UnitCharge;
            property.CityRefId = viewmodel.CityRefId;
            property.TypeRefId = viewmodel.TypeRefId;
            property.GroupRefId = viewmodel.GroupRefId;
            property.Location = viewmodel.Location;
            property.Summary = viewmodel.Summary;
            property.DirectionRefId = viewmodel.DirectionRefId;
            property.RoomCount = viewmodel.RoomCount;
            property.BathroomCount = viewmodel.BathroomCount;
            property.ParkingCount = viewmodel.ParkingCount;
            property.HeatingSystem= viewmodel.HeatingSystem;
            property.CoolingSystem= viewmodel.CoolingSystem;
            property.Floor= viewmodel.Floor;
            property.Unit= viewmodel.Unit;
            property.Area = viewmodel.Area;
            property.BaseArea = viewmodel.BaseArea;
            property.TerraceArea = viewmodel.TerraceArea;
            property.LandArea = viewmodel.LandArea;
            property.YardArea = viewmodel.YardArea;
            property.EnergyGrade= viewmodel.EnergyGrade;
            property.UsageRefId= viewmodel.UsageRefId;
            property.StatusRefId= viewmodel.StatusRefId;
            property.Tags = viewmodel.Tags;
            property.RentPeriodRefId= viewmodel.RentPeriodRefId;
            property.AgentRefId = viewmodel.AgentRefId;

            //upload photo 
            if (uploadPhoto != null)
            {
                if (!MyFile.IsImage(uploadPhoto))
                {
                    TempData["AlertMessage"] = AlertResource.NotValidPhotoFormatAlert;
                    TempData["AlertType"] = "alert-warning";

                    return View(viewmodel);
                }

                //delete old photo
                if (property.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(property.Photo!, "wwwroot/upload/realestate");
                }

                property.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/realestate");
            }

            //save realEstate
            await _realEstateRepository.Update(property);

            //option
            foreach (int opt in selectedOption)
            {
                var result = await _realEstateService.CheckPropertyHasOption(property.Id,opt);

                if (result == false)
                {
                    RealEstateJoinOption join = new RealEstateJoinOption()
                    {
                        OptionRefId = opt,
                        RealEstateRefId = property.Id
                    };
                    await _realEstateJoinOptionRepository.Add(join);
                }
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", "RealEstateAdminArea", new { id = property.Id });
        }

        [Route("admin/realestate/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _realEstateRepository.GetById(id);

            //delete old photo
            if (property.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(property.Photo!, "wwwroot/upload/realestate");
            }

            //photo list
            var photoList = await _realEstateService.GetPhotoListByRealEstateId(property.Id);
            foreach (var item in photoList)
            {
                //delete old photo
                if (item.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(item.Photo!, "wwwroot/upload/realestate");
                }

                await _realEstatePhotoRepository.Delete(item.Id);
            }

            //remove option list
            var optionList = await _realEstateService.GetOptionListByRealEstateId(property.Id);
            foreach (var item in optionList)
            {
                await _realEstateJoinOptionRepository.Delete(item.JoinId);
            }

            //save
            await _realEstateRepository.Delete(property.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        } 
        
        [Route("admin/realestate/option/remove/{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _realEstateJoinOptionRepository.GetById(id);

            int propertyId = option.RealEstateRefId!.Value;

            //save
            await _realEstateJoinOptionRepository.Delete(option.JoinId);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details",new{id = propertyId });
        }

        //upload photo's
        [HttpGet("admin/realestate/photo/upload/multi/{id}")]
        public async Task<IActionResult> UploadMulti(int id) // id = realEstate id
        {
            //real estate
            var realEstate = await _realEstateRepository.GetById(id);

            UploadRealEstatePhotoViewModel viewmodel = new UploadRealEstatePhotoViewModel()
            {
                RealEstateRefId = realEstate.Id,
                Title = realEstate.Title,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/realestate/photo/upload/multi/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadMulti(UploadRealEstatePhotoViewModel viewmodel, List<IFormFile> uploadPhotos)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //upload photo's
            if (!uploadPhotos.Any())
            {
                TempData["AlertMessage"] = AlertResource.NotSelectPhotoAlert;
                TempData["AlertType"] = "alert-warning";
                return View(viewmodel);
            }

            //real estate 
            var realEstate = await _realEstateRepository.GetById(viewmodel.RealEstateRefId!.Value);

            int i = 0;
            foreach (IFormFile item in uploadPhotos)
            {
                i++;
                if (MyFile.IsImage(item))
                {
                    RealEstatePhoto newPhoto = new RealEstatePhoto()
                    {
                        RealEstateRefId = realEstate.Id,
                        Title = viewmodel.Title,
                        Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate"),
                        Sort = i,
                    };

                    await _realEstatePhotoRepository.Add(newPhoto);
                }
            }

            //update realEstate
            realEstate.LastUpdate = MyDate.GetCurrentDate();
            await _realEstateRepository.Update(realEstate);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", "RealEstateAdminArea", new { id = realEstate.Id });

        }


        [Route("admin/realestate/photo/update/list/{id}")]
        public async Task<IActionResult> UpdatePhotoList(int id)
        {
            //real estate
            var realEstate = await _realEstateRepository.GetById(id);

            var photoList = await _realEstateService.GetPhotoListByRealEstateId(realEstate.Id);

            photoList = photoList.ToList();
            if (!photoList.Any())
            {
                TempData["AlertMessage"] = AlertResource.NoPhotoListExistAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = realEstate.Id });
            }

            List<UpdateRealEstatePhotoListByAdmin> viewmodelList = new List<UpdateRealEstatePhotoListByAdmin>();

            foreach (var item in photoList)
            {
                UpdateRealEstatePhotoListByAdmin viewmodel = new UpdateRealEstatePhotoListByAdmin
                {
                    Title = item.Title,
                    Photo = item.Photo,
                    PhotoRefId = item.Id,
                    Sort = item.Sort,
                };

                viewmodelList.Add(viewmodel);
            }
            return View(viewmodelList);
        }

        [HttpPost("admin/realestate/photo/update/list/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePhotoList(List<UpdateRealEstatePhotoListByAdmin> viewmodelList)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodelList);
            }

            int realEstateId = 0;
            foreach (var item in viewmodelList)
            {
                //photo
                var photo = await _realEstatePhotoRepository.GetById(item.PhotoRefId!.Value);

                //update
                photo.Title = item.Title;
                photo.Sort = item.Sort;

                //save
                await _realEstatePhotoRepository.Update(photo);

                realEstateId = photo.RealEstateRefId!.Value;
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            if (realEstateId != 0)
            {
                return RedirectToAction("Details", "RealEstateAdminArea", new { id = realEstateId });
            }

            return RedirectToAction("Index");

        }

        [Route("admin/realestate/photo/remove/list/{id}")]
        public async Task<IActionResult> RemoveSelectedPhoto(int id)
        {
            //real estate
            var realEstate = await _realEstateRepository.GetById(id);

            var photoList = await _realEstateService.GetPhotoListByRealEstateId(realEstate.Id);

            photoList = photoList.ToList();
            if (!photoList.Any())
            {
                TempData["AlertMessage"] = AlertResource.NoPhotoListExistAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = realEstate.Id });
            }

            List<RemoveRealEstatePhotoListByAdmin> viewmodelList = new List<RemoveRealEstatePhotoListByAdmin>();

            foreach (var item in photoList)
            {
                RemoveRealEstatePhotoListByAdmin viewmodel = new RemoveRealEstatePhotoListByAdmin
                {
                    Title = item.Title,
                    Photo = item.Photo,
                    PhotoRefId = item.Id,
                    Sort = item.Sort,
                    CheckStatus = false,
                };

                viewmodelList.Add(viewmodel);
            }
            return View(viewmodelList);
        }

        [HttpPost("admin/realestate/photo/remove/list/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSelectedPhoto(List<RemoveRealEstatePhotoListByAdmin> viewmodelList, List<int> selectedPhoto)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodelList);
            }

            int realEstateId = 0;
            foreach (var item in selectedPhoto)
            {
                //photo
                var photo = await _realEstatePhotoRepository.GetById(item);

                //delete photo
                if (photo.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(photo.Photo!, "wwwroot/upload/realestate");
                }

                //save
                await _realEstatePhotoRepository.Delete(photo.Id);

                realEstateId = photo.RealEstateRefId!.Value;
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            if (realEstateId != 0)
            {
                return RedirectToAction("Details", "RealEstateAdminArea", new { id = realEstateId });
            }

            return RedirectToAction("Index");

        }

        [Route("admin/realestate/photo/remove/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await _realEstatePhotoRepository.GetById(id);

            int realEstateId = photo.RealEstateRefId!.Value;

            //delete photo
            if (photo.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(photo.Photo!, "wwwroot/upload/realestate");
            }

            //save
            await _realEstatePhotoRepository.Delete(photo.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = realEstateId });
        }

        [Route("admin/realestate/photo/remove/all/{id}")]
        public async Task<IActionResult> DeleteAllPhoto(int id)//id = property id
        {
            var property = await _realEstateRepository.GetById(id);

            var photoList = await _realEstateService.GetPhotoListByRealEstateId(property.Id);

            foreach (var item in photoList)
            {
                if (item.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(item.Photo!, "wwwroot/upload/realestate");
                }

                await _realEstatePhotoRepository.Delete(item.Id);
            }


            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = property.Id });
        }

    }
}
