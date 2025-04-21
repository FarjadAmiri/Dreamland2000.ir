using WebSite.Core.Services;
using WebSite.DataLayer.Entities.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Blog;
using Language = WebSite.DataLayer.Entities.Language.Language;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Areas.Admin.Controllers
{
    public class BlogAdminAreaController : BaseController
    {
        private readonly IGenericRepository<Blog> _blogRepository;
        private readonly IGenericRepository<BlogPhoto> _blogPhotoRepository;
        private readonly IGenericRepository<BlogGroup> _groupRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IBlogService _blogService;
        private readonly ILanguageService _languageService;
        private readonly IUploadService _uploadService;

        public BlogAdminAreaController(IGenericRepository<Blog> blogRepository, IGenericRepository<BlogGroup> groupRepository, IBlogService blogService, IUploadService uploadService, IGenericRepository<BlogPhoto> blogPhotoRepository, ILanguageService languageService, IGenericRepository<Language> languageRepository)
        {
            _blogRepository = blogRepository;
            _groupRepository = groupRepository;
            _blogService = blogService;
            _uploadService = uploadService;
            _blogPhotoRepository = blogPhotoRepository;
            _languageService = languageService;
            _languageRepository = languageRepository;
        }

        [Route("admin/blog/list")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var blogList = await _blogService.GetBlogList(page, 100);
            return View(blogList);
        }


        //blog profile 
        [Route("admin/blog/profile/{id}")]
        public async Task<IActionResult> Details(int id) // id = blog id
        {
            //blog 
            var blog = await _blogRepository.GetById(id);

            //group 
            if (blog.GroupRefId == null)
            {
                return NotFound();
            }
            var group = await _groupRepository.GetById(blog.GroupRefId.Value);
            blog.Group = group;


            return View(blog);
        }

        //new blog post 
        [Route("admin/blog/new")]
        public async Task<IActionResult> Create(int language)
        {
            //language
            var lang = await _languageRepository.GetById(language);

            AddNewBlogByAdminViewModel viewmodel = new AddNewBlogByAdminViewModel()
            {
                LanguageRefId = language,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
                BlogDate = MyDate.GetCurrentDate(),
                Author = "Dreamland2000",
                Tags = "Dreamland 2000,Blog,Spain Real estate"
            };

            //group 
            var groupList = await _blogService.GetBlogGroupList(language);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title");


            return View(viewmodel);
        }

        [HttpPost("admin/blog/new"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewBlogByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //group 
            var groupList = await _blogService.GetBlogGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title", viewmodel.GroupRefId);

            //check blog date validation 
            if (viewmodel.BlogDate == null)
            {
                TempData["AlertMessage"] = AlertResource.NotSelectedDateAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //blog
            Blog blog = new Blog()
            {
                Title = viewmodel.Title,
                Summary = viewmodel.Summary,
                Content = viewmodel.Content,
                Author = viewmodel.Author,
                Tags = viewmodel.Tags,
                GroupRefId = viewmodel.GroupRefId,
                BlogDate = viewmodel.BlogDate,
                LanguageRefId = viewmodel.LanguageRefId
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
                blog.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/blog");
            }

            //save
            await _blogRepository.Add(blog);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = blog.Id });
        }

        //update post 
        [Route("admin/blog/update/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            //blog
            var blog = await _blogRepository.GetById(id);

            //language
            var lang = await _languageRepository.GetById(blog.LanguageRefId!.Value);

            UpdateBlogByAdminViewModel viewmodel = new UpdateBlogByAdminViewModel()
            {
                Title = blog.Title,
                Summary = blog.Summary,
                Content = blog.Content,
                Author = blog.Author,
                GroupRefId = blog.GroupRefId,
                BlogRefId = blog.Id,
                Photo = blog.Photo,
                Tags = blog.Tags,
                BlogDate = blog.BlogDate,
                LanguageRefId = blog.LanguageRefId,
                LanguageEnglishTitle = lang.TitleEnglish,
                LanguageShortTitle = lang.ShortTitle,
            };

            //group 
            var groupList = await _blogService.GetBlogGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title",viewmodel.GroupRefId);

            return View(viewmodel);
        }

        [HttpPost("admin/blog/update/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBlogByAdminViewModel viewmodel, IFormFile? uploadPhoto)
        {
            //blog
            var blog = await _blogRepository.GetById(viewmodel.BlogRefId);

            //group 
            var groupList = await _blogService.GetBlogGroupList(viewmodel.LanguageRefId!.Value);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title",viewmodel.GroupRefId);


            //check blog date validation 
            if (viewmodel.BlogDate == null)
            {
                TempData["AlertMessage"] = AlertResource.NotSelectedDateAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //check model validation
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = AlertResource.FailRequestAlert;
                TempData["AlertType"] = "alert-warning";

                return View(viewmodel);
            }

            //update blog
            blog.Title = viewmodel.Title;
            blog.Summary = viewmodel.Summary;
            blog.Content = viewmodel.Content;
            blog.Author = viewmodel.Author;
            blog.Tags = viewmodel.Tags;
            blog.GroupRefId = viewmodel.GroupRefId;
            blog.BlogDate = viewmodel.BlogDate;


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
                if (blog.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(blog.Photo!, "wwwroot/upload/blog");
                }

                blog.Photo = _uploadService.UploadPhoto(uploadPhoto, "wwwroot/upload/blog");
            }

            //save blog
            await _blogRepository.Update(blog);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = blog.Id });
        }

        //remove post 
        [Route("admin/blog/remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogRepository.GetById(id);

            //delete old photo
            if (blog.Photo != "default.jpg")
            {
                _uploadService.RemovePhoto(blog.Photo!, "wwwroot/upload/blog");
            }

            //remove photo list
            var photoList = await _blogService.GetPhotoListByBlogId(blog.Id);
            foreach (var item in photoList)
            {
                if (item.Photo != "default.jpg")
                {
                    _uploadService.RemovePhoto(item.Photo!, "wwwroot/upload/blog");
                }

                await _blogPhotoRepository.Delete(item.Id);
            }    

            //save
            await _blogRepository.Delete(blog.Id);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Index");
        }

        //upload photo's
        [HttpGet("admin/blog/photo/upload/multi/{id}")]
        public async Task<IActionResult> UploadMulti(int id) // id = blog id
        {
            //blog
            var blog = await _blogRepository.GetById(id);

            UploadBlogPhotoViewModel viewmodel = new UploadBlogPhotoViewModel()
            {
                BlogRefId = blog.Id,
                Title = blog.Title,
            };

            return View(viewmodel);
        }

        [HttpPost("admin/blog/photo/upload/multi/{id}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadMulti(UploadBlogPhotoViewModel viewmodel, List<IFormFile> uploadPhotos)
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

            //blog 
            var blog = await _blogRepository.GetById(viewmodel.BlogRefId!.Value);

            int i = 0;
            foreach (IFormFile item in uploadPhotos)
            {
                i++;
                if (MyFile.IsImage(item))
                {
                    BlogPhoto newPhoto = new BlogPhoto()
                    {
                        BlogRefId = blog.Id,
                        Title = viewmodel.Title,
                        Photo = _uploadService.UploadPhoto(item, "wwwroot/upload/blog"),
                    };

                    await _blogPhotoRepository.Add(newPhoto);
                }
            }

            //update blog
            blog.LastUpdate = MyDate.GetCurrentDate();
            await _blogRepository.Update(blog);

            TempData["AlertMessage"] = AlertResource.SuccessRequestAlert;
            TempData["AlertType"] = "alert-success";

            return RedirectToAction("Details", new { id = blog.Id });

        }

    }
}
