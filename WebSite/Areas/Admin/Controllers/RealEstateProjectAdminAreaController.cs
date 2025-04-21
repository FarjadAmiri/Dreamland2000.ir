using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Core.Services;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.RealEstate;
using WebSite.DataLayer.Entities.Address;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.RealEstate;
using Language = WebSite.DataLayer.Entities.Language.Language;

namespace WebSite.Areas.Admin.Controllers
{
    public class RealEstateProjectAdminAreaController : BaseController
    {
        
        private readonly IGenericRepository<RealEstateProject> _projectRepository;
        private readonly IGenericRepository<RealEstateProjectStatus> _projectStatusRepository;
        private readonly IGenericRepository<RealEstateProjectPhoto> _projectPhotoRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IRealEstateService _realEstateService;
        private readonly IUploadService _uploadService;
        private readonly IAddressService _addressService;
        private readonly IAgentService _agentService;


        public RealEstateProjectAdminAreaController(IGenericRepository<RealEstateProject> projectRepository, IGenericRepository<RealEstateProjectPhoto> projectPhotoRepository, IGenericRepository<City> cityRepository, IGenericRepository<Language> languageRepository, IGenericRepository<Agent> agentRepository, IRealEstateService projectService, IUploadService uploadService, IAddressService addressService, IAgentService agentService, IGenericRepository<RealEstateProjectStatus> projectStatusRepository)
        {
            _projectRepository = projectRepository;
            _projectPhotoRepository = projectPhotoRepository;
            _cityRepository = cityRepository;
            _languageRepository = languageRepository;
            _agentRepository = agentRepository;
            _realEstateService = projectService;
            _uploadService = uploadService;
            _addressService = addressService;
            _agentService = agentService;
            _projectStatusRepository = projectStatusRepository;
        }

        [Route("admin/realestate/project/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var projectList = await _realEstateService.GetProjectList(page,100);

            return View(projectList);
        }

        [Route("admin/realestate/project/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = project id
        {
            //real estate 
            var project = await _projectRepository.GetById(id);

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
            if (project.StatusRefId!= null)
            {
                var status = await _projectStatusRepository.GetById(project.StatusRefId!.Value);
                project.Status= status;
            }

            //language 
            if (project.LanguageRefId != null)
            {
                var language = await _languageRepository.GetById(project.LanguageRefId!.Value);
                project.Language = language;
            }

            return View(project);
        }


        [Route("admin/realestate/project/new")]
        public async Task<IActionResult> Create(int language)
        {
            //city
            var cityList = await _addressService.GetCityList(language);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title");

            //agent
            var agentList = await _agentService.GetAgentList(language);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name");

            //status
            var statusList = await _realEstateService.GetProjectStatusList(language);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title");

            //language
            var lang = await _languageRepository.GetById(language);


            AddNewRealEstateProjectByAdminViewModel viewmodel = new AddNewRealEstateProjectByAdminViewModel()
            {
                LanguageRefId = language,
                Tags = "Dreamland2000,Real estate,",
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/realestate/project/new"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewRealEstateProjectByAdminViewModel viewmodel, List<IFormFile> uploadPhotos)
        {
            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId!.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title",viewmodel.CityRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId!.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //status
            var statusList = await _realEstateService.GetProjectStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //new project
            RealEstateProject project = new RealEstateProject()
            {
                Title = viewmodel.Title,
                ShortTitle= viewmodel.ShortTitle,
                Code = viewmodel.Code,
                CityRefId = viewmodel.CityRefId,
                StatusRefId= viewmodel.StatusRefId,
                Summary = viewmodel.Summary,
                Room= viewmodel.Room,
                Bathroom= viewmodel.Bathroom,
                Tags = viewmodel.Tags,
                LanguageRefId = viewmodel.LanguageRefId,
                Area = viewmodel.Area,
                Location = viewmodel.Location,
                Price = viewmodel.Price,
                AgentRefId = viewmodel.AgentRefId,
            };

            //save
            await _projectRepository.Add(project);

            int i = 0;
            //upload photo list
            foreach (IFormFile item in uploadPhotos)
            {
                i++;
                if (MyFile.IsImage(item))
                {
                    RealEstateProjectPhoto newPhoto = new RealEstateProjectPhoto()
                    {
                        ProjectRefId = project.Id,
                        Title = viewmodel.Title,
                        Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate"),
                        Sort = i,
                    };

                    await _projectPhotoRepository.Add(newPhoto);

                    //update main photo
                    if (project.Photo == "default.jpg")
                    {
                        project.Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate");
                        await _projectRepository.Update(project);
                    }
                }
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            var photoList = await _realEstateService.GetPhotoListByRealEstateId(project.Id);
            if (photoList.Any())
            {
                return RedirectToAction("UpdatePhotoList", new { id = project.Id });
            }
            return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = project.Id });
        }

        //update post 
        [Route("admin/realestate/project/update/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            //project
            var project = await _projectRepository.GetById(id);


            //language
            var lang = await _languageRepository.GetById(project.LanguageRefId!.Value);

            UpdateRealEstateProjectByAdminViewModel viewmodel = new UpdateRealEstateProjectByAdminViewModel()
            {
                Title = project.Title,
                ShortTitle = project.ShortTitle,
                Summary = project.Summary,
                Room= project.Room,
                Bathroom = project.Bathroom,
                AgentRefId = project.AgentRefId,
                CityRefId = project.CityRefId,
                StatusRefId = project.StatusRefId,
                ProjectRefId = project.Id,
                Photo = project.Photo,
                Tags = project.Tags,
                Area = project.Area,
                Location = project.Location,
                Price = project.Price,
                Code = project.Code,
                LanguageRefId = project.LanguageRefId,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId!.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title", viewmodel.CityRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId!.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //status
            var statusList = await _realEstateService.GetProjectStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            return View(viewmodel);
        }

        [HttpPost("admin/realestate/project/update/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateRealEstateProjectByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //city
            var cityList = await _addressService.GetCityList(viewmodel.LanguageRefId!.Value);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title", viewmodel.CityRefId);

            //agent
            var agentList = await _agentService.GetAgentList(viewmodel.LanguageRefId!.Value);
            ViewBag.AgentRefId = new SelectList(agentList,
                "Id", "Name", viewmodel.AgentRefId);

            //status
            var statusList = await _realEstateService.GetProjectStatusList(viewmodel.LanguageRefId!.Value);
            ViewBag.StatusRefId = new SelectList(statusList,
                "Id", "Title", viewmodel.StatusRefId);

            
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //project
            var project = await _projectRepository.GetById(viewmodel.ProjectRefId!.Value);

            //update project
            project.Title = viewmodel.Title;
            project.Code = viewmodel.Code;
            project.Price = viewmodel.Price;
            project.CityRefId = viewmodel.CityRefId;
            project.StatusRefId = viewmodel.StatusRefId;
            project.Location = viewmodel.Location;
            project.Summary = viewmodel.Summary;
            project.Room = viewmodel.Room;
            project.Bathroom = viewmodel.Bathroom;
            project.Area = viewmodel.Area;
            project.Tags = viewmodel.Tags;
            project.AgentRefId = viewmodel.AgentRefId;

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
                if (project.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(project.Photo!, "wwwroot/upload/realestate");
                }

                project.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/realestate");
            }

            //save project
            await _projectRepository.Update(project);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = project.Id });
        }

        [Route("admin/realestate/project/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepository.GetById(id);

            //delete old photo
            if (project.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(project.Photo!, "wwwroot/upload/realestate");
            }

            //photo list
            var photoList = await _realEstateService.GetPhotoListByProjectId(project.Id);
            foreach (var item in photoList)
            {
                //delete old photo
                if (item.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(item.Photo!, "wwwroot/upload/realestate");
                }

                await _projectPhotoRepository.Delete(item.Id);
            }

            //save
            await _projectRepository.Delete(project.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }

        //upload photo's
        [HttpGet("admin/realestate/project/photo/upload/multi/{id}")]
        public async Task<IActionResult> UploadMulti(int id) // id = project id
        {
            //project
            var project = await _projectRepository.GetById(id);

            UploadRealEstateProjectPhotoViewModel viewmodel = new UploadRealEstateProjectPhotoViewModel()
            {
                ProjectRefId = project.Id,
                Title = project.Title,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/realestate/project/photo/upload/multi/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadMulti(UploadRealEstateProjectPhotoViewModel viewmodel, List<IFormFile> uploadPhotos)
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
            var project = await _projectRepository.GetById(viewmodel.ProjectRefId!.Value);

            int i = 0;
            foreach (IFormFile item in uploadPhotos)
            {
                i++;
                if (MyFile.IsImage(item))
                {
                    RealEstateProjectPhoto newPhoto = new RealEstateProjectPhoto()
                    {
                        ProjectRefId = project.Id,
                        Title = viewmodel.Title,
                        Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/realestate"),
                        Sort = i,
                    };

                    await _projectPhotoRepository.Add(newPhoto);

                    //update main photo
                    if (project.Photo == "default.jpg")
                    {
                        project.Photo = newPhoto.Photo;
                        await _projectRepository.Update(project);
                    }
                }
            }

            //update project
            project.LastUpdate = MyDate.GetCurrentDate();
            await _projectRepository.Update(project);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = project.Id });

        }


        [Route("admin/realestate/project/photo/update/list/{id}")]
        public async Task<IActionResult> UpdatePhotoList(int id)
        {
            //project
            var project = await _projectRepository.GetById(id);


            var photoList = await _realEstateService.GetPhotoListByProjectId(project.Id);

            photoList = photoList.ToList();

            if (!photoList.Any())
            {
                TempData["AlertMessage"] = AlertResource.NoPhotoListExistAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = project.Id });
            }
            List<UpdateRealEstateProjectPhotoListByAdmin> viewmodelList = new List<UpdateRealEstateProjectPhotoListByAdmin>();

            foreach (var item in photoList)
            {
                UpdateRealEstateProjectPhotoListByAdmin viewmodel = new UpdateRealEstateProjectPhotoListByAdmin
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

        [HttpPost("admin/realestate/project/photo/update/list/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePhotoList(List<UpdateRealEstateProjectPhotoListByAdmin> viewmodelList)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodelList);
            }

            int projectId = 0;
            foreach (var item in viewmodelList)
            {
                //photo
                var photo = await _projectPhotoRepository.GetById(item.PhotoRefId!.Value);

                //update
                photo.Title = item.Title;
                photo.Sort = item.Sort;

                //save
                await _projectPhotoRepository.Update(photo);

                projectId = photo.ProjectRefId!.Value;
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            if (projectId != 0)
            {
                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = projectId });
            }

            return RedirectToAction("Index");

        }



        [Route("admin/realestate/project/photo/remove/list/{id}")]
        public async Task<IActionResult> RemoveSelectedPhoto(int id)
        {
            //project
            var project = await _projectRepository.GetById(id);

            var photoList = await _realEstateService.GetPhotoListByProjectId(project.Id);

            photoList = photoList.ToList();
            if (!photoList.Any())
            {
                TempData["AlertMessage"] = AlertResource.NoPhotoListExistAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = project.Id });
            }

            List<RemoveRealEstateProjectPhotoListByAdmin> viewmodelList = new List<RemoveRealEstateProjectPhotoListByAdmin>();

            foreach (var item in photoList)
            {
                RemoveRealEstateProjectPhotoListByAdmin viewmodel = new RemoveRealEstateProjectPhotoListByAdmin
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

        [HttpPost("admin/realestate/project/photo/remove/list/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSelectedPhoto(List<RemoveRealEstateProjectPhotoListByAdmin> viewmodelList, List<int> selectedPhoto)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodelList);
            }

            int projectId = 0;
            foreach (var item in selectedPhoto)
            {
                //photo
                var photo = await _projectPhotoRepository.GetById(item);

                //delete photo
                if (photo.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(photo.Photo!, "wwwroot/upload/realestate");
                }

                //save
                await _projectPhotoRepository.Delete(photo.Id);

                projectId = photo.ProjectRefId!.Value;
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            if (projectId != 0)
            {
                return RedirectToAction("Details", "RealEstateProjectAdminArea", new { id = projectId });
            }

            return RedirectToAction("Index");

        }

        [Route("admin/realestate/project/photo/remove/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await _projectPhotoRepository.GetById(id);

            int projectId = photo.ProjectRefId!.Value;

            //delete photo
            if (photo.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(photo.Photo!, "wwwroot/upload/realestate");
            }

            //save
            await _projectPhotoRepository.Delete(photo.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = projectId });
        }

        [Route("admin/realestate/project/photo/remove/all/{id}")]
        public async Task<IActionResult> DeleteAllPhoto(int id)//id = property id
        {
            var project = await _projectRepository.GetById(id);

            var photoList = await _realEstateService.GetPhotoListByProjectId(project.Id);

            foreach (var item in photoList)
            {
                if (item.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(item.Photo!, "wwwroot/upload/realestate");
                }

                await _projectPhotoRepository.Delete(item.Id);
            }

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = project.Id });
        }

    }
}
