using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.Blog;
using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IGenericRepository<Blog> _blogRepository;
        private readonly IGenericRepository<BlogComment> _blogCommentRepository;
        private readonly IGenericRepository<BlogGroup> _blogGroupRepository;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IBlogService _blogService;
        private readonly IAboutService _aboutService;
        private readonly IUserService _userService;

        public BlogController(IGenericRepository<Blog> blogRepository, IBlogService blogService, IGenericRepository<BlogGroup> blogGroupRepository, IUserService userService, IGenericRepository<BlogComment> blogCommentRepository, ICaptchaValidator captchaValidator, IAboutService aboutService)
        {
            _blogRepository = blogRepository;
            _blogService = blogService;
            _blogGroupRepository = blogGroupRepository;
            _userService = userService;
            _blogCommentRepository = blogCommentRepository;
            _captchaValidator = captchaValidator;
            _aboutService = aboutService;
        }

        [Route("blog")]
        public async Task<IActionResult> Index(int page = 1, int group = -1, string search = "")
        {
            var blogList = await _blogService.GetBlogList(page, group, search,24,1);

          //filter
            ViewBag.GroupId = group;
            ViewBag.Search = search;


            ViewBag.Navbar = "Blog";

            return View(blogList);
        }

        [Route("blog/{id}")]
        public async Task<IActionResult> Details(int id) // id = blog id
        {
            //blog 
            var blog = await _blogRepository.GetById(id);

            //visit ++
            await _blogService.VisitPlusBlogByBlogId(blog.Id);

            //group list 
            var blogGroupList = await _blogService.GetBlogGroupList(1);
            ViewBag.BlogGroupList = blogGroupList;

            //group 
            if (blog.GroupRefId != null)
            {
                var group = await _blogGroupRepository.GetById(blog.GroupRefId.Value);
                blog.Group = group;
            }

            //comment list
            var commentList = await _blogService.GetAcceptedBlogCommentListByBlogId(blog.Id);
            blog.CommentList = commentList.ToList();

            //photo list
            var photoList = await _blogService.GetPhotoListByBlogId(blog.Id);
            blog.PhotoList = photoList.ToList();

            ViewBag.Navbar = "Blog";

            return View(blog);
        }


        [HttpPost("blog/comment/send")]
        public async Task<IActionResult> SendComment(BlogSendCommentViewModel viewmodel)
        {
            //google recaptcha validation
            if (!await _captchaValidator.IsCaptchaPassedAsync(viewmodel.Captcha))
            {
                TempData["AlertMessage"] = AlertResource.FailedReCaptchaAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.BlogRefId });
            }
            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return RedirectToAction("Details", new { id = viewmodel.BlogRefId });
            }

            //new comment
            BlogComment newComment = new BlogComment()
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Tell = viewmodel.Tell,
                Comment = viewmodel.Comment,
                BlogRefId = viewmodel.BlogRefId,
            };

            if (User.Identity!.IsAuthenticated)
            {
                //current user 
                var userName = User.Identity!.Name;
                var currentUser = await _userService.GetCurrentUserByUserName(userName!);
                newComment.UserRefId = currentUser.Id;
            }
            //save comment
            await _blogCommentRepository.Add(newComment);

            TempData["AlertMessage"] = AlertResource.CommentSentSuccessfulAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = newComment.BlogRefId });
        }

        //search 
        [HttpPost("blog/search"), ValidateAntiForgeryToken]
        public IActionResult Search(BlogSearchViewModel viewmodel)
        {
            return RedirectToAction("Index", new { search = viewmodel.SearchText });

        }


    }
}