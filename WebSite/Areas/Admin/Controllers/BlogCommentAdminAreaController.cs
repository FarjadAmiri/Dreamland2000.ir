using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Blog;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.Controllers
{
    public class BlogCommentAdminAreaController : BaseController
    {
        private readonly IGenericRepository<Blog> _blogRepository;
        private readonly IGenericRepository<BlogComment> _blogCommentRepository;
        private readonly IBlogService _blogService;

        public BlogCommentAdminAreaController(IGenericRepository<Blog> blogRepository, IBlogService blogService, IGenericRepository<BlogComment> blogCommentRepository)
        {
            _blogRepository = blogRepository;
            _blogService = blogService;
            _blogCommentRepository = blogCommentRepository;
        }

        //blog list
        [HttpGet("admin/blog/comment/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var commentList = await _blogService.GetBlogCommentList(page);
            return View(commentList);
        }
        
        //comment profile
        [HttpGet("admin/blog/comment/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = comment id
        {
            //comment
            var comment = await _blogCommentRepository.GetById(id);
            //blog 
            if (comment.BlogRefId != null)
            {
                var blog = await _blogRepository.GetById(comment.BlogRefId.Value);
                comment.Blog = blog;
            }
            return View(comment);
        }

      
        //remove comment
        [HttpGet("admin/blog/comment/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //comment
            var comment = await _blogCommentRepository.GetById(id);
            
            //remove
            await _blogCommentRepository.Delete(comment.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }
        
    }
}
