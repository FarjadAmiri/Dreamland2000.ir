using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class BlogLatestList3Col : ViewComponent
    {
        
        private readonly IBlogService _blogService;

        public BlogLatestList3Col(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogList = await _blogService.GetBlogLatestList(10,3);

            return await Task.FromResult((IViewComponentResult)View("BlogLatestList3Col", blogList));
        }
    }
}
