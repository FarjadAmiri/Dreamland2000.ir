using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Agent;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Agent;
using WebSite.DataLayer.Entities.RealEstate;
using Language = WebSite.DataLayer.Entities.Language.Language;
using WebSite.DataLayer.Entities.Language;

namespace WebSite.Areas.Admin.Controllers
{
    public class AgentAdminAreaController : BaseController
    {
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IGenericRepository<RealEstate> _realEstateRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IAgentService _agentService;
        private readonly IRealEstateService _realEstateService;
        private readonly IUploadService _uploadService;


        public AgentAdminAreaController(IGenericRepository<Agent> agentRepository, IGenericRepository<RealEstate> realEstateRepository, IAgentService agentService, IRealEstateService realEstateService, IUploadService uploadService, IGenericRepository<Language> languageRepository)
        {
            _agentRepository = agentRepository;
            _realEstateRepository = realEstateRepository;
            _agentService = agentService;
            _realEstateService = realEstateService;
            _uploadService = uploadService;
            _languageRepository = languageRepository;
        }

        [Route("admin/agent/list")]
        public async Task<IActionResult> Index()
        {
            var agentList = await _agentService.GetAgentList();
            return View(agentList);
        }


        //agent profile 
        [Route("admin/agent/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = agent id
        {
            //agent 
            var agent = await _agentRepository.GetById(id);

            //language 
            if (agent.LanguageRefId != null)
            {
                var language = await _languageRepository.GetById(agent.LanguageRefId!.Value);
                agent.Language = language;
            }

            return View(agent);
        }

        //new agent post 
        [Route("admin/agent/new")]
        public async Task<IActionResult> Create(int language)
        {
            //language
            var lang = await _languageRepository.GetById(language);

            AddNewAgentByAdminViewModel viewmodel = new AddNewAgentByAdminViewModel()
            {
                LanguageRefId =language,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/agent/new"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewAgentByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //agent
            Agent agent = new Agent()
            {
                Name = viewmodel.Name,
                Summary = viewmodel.Summary,
                Responsibility = viewmodel.Responsibility,
                Tell = viewmodel.Tell,
                Email = viewmodel.Email,
                Address= viewmodel.Address,
                Sort = viewmodel.Sort,
                LanguageRefId = viewmodel.LanguageRefId,
            };

            //upload photo 
            if (uploadPhoto != null)
            {
                if (!MyFile.IsImage(uploadPhoto))
                {
                    TempData["AlertMessage"] = AlertResource.NotValidPhotoFormatAlert;
                    TempData["AlertType"] = "alert-warning";

                    return View(viewmodel);
                }
                agent.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/agent");
            }

            //save
            await _agentRepository.Add(agent);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details",new{id = agent.Id});
        }

        //update post 
        [Route("admin/agent/update/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            //agent
            var agent = await _agentRepository.GetById(id);

            //language
            var lang = await _languageRepository.GetById(agent.LanguageRefId!.Value);

            UpdateAgentByAdminViewModel viewmodel = new UpdateAgentByAdminViewModel()
            {
                Name = agent.Name,
                Responsibility = agent.Responsibility,
                Summary = agent.Summary,
                Tell= agent.Tell,
                Email= agent.Email,
                Address= agent.Address,
                AgentRefId = agent.Id,
                Photo = agent.Photo,
                Sort = agent.Sort,
                LanguageRefId = lang.Id,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/agent/update/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateAgentByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //agent
            var agent = await _agentRepository.GetById(viewmodel.AgentRefId!.Value);

            //update agent
            agent.Name = viewmodel.Name;
            agent.Responsibility= viewmodel.Responsibility;
            agent.Summary= viewmodel.Summary;
            agent.Tell= viewmodel.Tell;
            agent.Email= viewmodel.Email;
            agent.Address= viewmodel.Address;
            agent.Sort = viewmodel.Sort;

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
                if (agent.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(agent.Photo!, "wwwroot/upload/agent");
                }

                agent.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/agent");
            }

            //save agent
            await _agentRepository.Update(agent);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = agent.Id });
        }

        //remove post 
        [Route("admin/agent/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agent = await _agentRepository.GetById(id);

            //real estate list
            var realEstateList = await _realEstateService.GetRealEstateListByAgentId(agent.Id);

            foreach (var item in realEstateList)
            {
                item.AgentRefId = null;
                await _realEstateRepository.Update(item);
            }

            //delete photo
            if (agent.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(agent.Photo!, "wwwroot/upload/agent");
            }

            //delete
            await _agentRepository.Delete(agent.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }
    }
}
