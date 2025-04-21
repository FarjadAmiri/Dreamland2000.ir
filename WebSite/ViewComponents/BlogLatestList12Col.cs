using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class BlogLatestList12Col : ViewComponent
    {

        private readonly IBlogService _blogService;

        public BlogLatestList12Col(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var blogList = await _blogService.GetBlogLatestList(3,1);

            return await Task.FromResult((IViewComponentResult)View("BlogLatestList12Col", blogList));
        }
    }
}
