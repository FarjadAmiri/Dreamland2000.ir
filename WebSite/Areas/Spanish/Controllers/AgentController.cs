using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.Agent;
using WebSite.DataLayer.Entities.Agent;

namespace WebSite.Areas.Spanish.Controllers
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

        [Route("es/agent")]
        public async Task<IActionResult> Index()
        {
            var agentList = await _agentService.GetAgentList(3);

            ViewBag.Navbar = "Agent";

            return View(agentList);
        }

        [Route("es/agent/{id}")]
        public async Task<IActionResult> Details(int id) // id = agent id
        {
            //agent 
            var agent = await _agentRepository.GetById(id);

            //visit ++
            await _agentService.VisitPlusAgentByAgentId(agent.Id);

            ViewBag.Navbar = "Agent";

            return View(agent);
        }

        [HttpPost("es/agent/message/send")]
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

            return RedirectToAction("Details",new{id = msg.AgentRefId});
        }

    }
}