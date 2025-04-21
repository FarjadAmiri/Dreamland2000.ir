using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Agent;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    public class AgentCommentAdminAreaController : BaseController
    {
        private readonly IGenericRepository<Agent> _agentRepository;
        private readonly IGenericRepository<AgentComment> _agentCommentRepository;
        private readonly IAgentService _agentService;

        public AgentCommentAdminAreaController(IGenericRepository<Agent> agentRepository, IAgentService agentService, IGenericRepository<AgentComment> agentCommentRepository)
        {
            _agentRepository = agentRepository;
            _agentService = agentService;
            _agentCommentRepository = agentCommentRepository;
        }

        //agent list
        [HttpGet("admin/agent/comment/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var commentList = await _agentService.GetAgentCommentList(page);
            return View(commentList);
        }
        
        //comment profile
        [HttpGet("admin/agent/comment/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = comment id
        {
            //comment
            var comment = await _agentCommentRepository.GetById(id);
            //agent 
            if (comment.AgentRefId != null)
            {
                var agent = await _agentRepository.GetById(comment.AgentRefId.Value);
                comment.Agent = agent;
            }
            return View(comment);
        }

      
        //remove comment
        [HttpGet("admin/agent/comment/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //comment
            var comment = await _agentCommentRepository.GetById(id);
            
            //remove
            await _agentCommentRepository.Delete(comment.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }
        
    }
}
