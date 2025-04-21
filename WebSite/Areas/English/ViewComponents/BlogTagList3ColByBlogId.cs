using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Areas.English.ViewComponents
{
    public class BlogTagList3ColByBlogId : ViewComponent
    {

        private readonly IGenericRepository<Blog> _blogRepository;

        public BlogTagList3ColByBlogId(IGenericRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blog = await _blogRepository.GetById(id);

            return await Task.FromResult((IViewComponentResult)View("BlogTagList3ColByBlogId", blog));
        }
    }
}
