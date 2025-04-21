using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.Agent;
using WebSite.Core.ViewModel.Contact;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.Contact;

namespace WebSite.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IGenericRepository<AgentMessage> _agentMessageRepository;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IAgentService _agentService;
        
        public AgentController(IGenericRepository<Agent> agentRepository, IAgentService agentService, IGenericRepository<AgentMessage> agentMessageRepository, ICaptchaValidator captchaValidator)
        {
            _agentRepository = agentRepository;
            _agentService = agentService;
            _agentMessageRepository = agentMessageRepository;
            _captchaValidator = captchaValidator;
        }

        [Route("agent")]
        public async Task<IActionResult> Index()
        {
            var agentList = await _agentService.GetAgentList(1);

            ViewBag.Navbar = "Agent";

            return View(agentList);
        }

        [Route("agent/{id}")]
        public async Task<IActionResult> Details(int id) // id = agent id
        {
            //agent 
            var agent = await _agentRepository.GetById(id);

            //visit ++
            await _agentService.VisitPlusAgentByAgentId(agent.Id);

            ViewBag.Navbar = "Agent";

            return View(agent);
        }

        [HttpPost("agent/message/send")]
        public async Task<IActionResult> SendMessage(AgentSendMessageViewModel viewmodel)
        {
            //check google recaptcha
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Index");
            }

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Index");
            }

            //new message
            AgentMessage msg = new AgentMessage()
            {
                SenderName = viewmodel.Name,
                SenderEmail = viewmodel.Email,
                SenderTell = viewmodel.Tell,
                Message = viewmodel.Message,
                AgentRefId =viewmodel.AgentRefId, 
            };

            //save message
            await _agentMessageRepository.Add(msg);

            TempData["AlertMessage"] = AlertResource.MessageSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }

    }
}