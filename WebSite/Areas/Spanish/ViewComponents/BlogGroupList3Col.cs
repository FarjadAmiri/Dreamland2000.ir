using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class BlogGroupList3Col : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogGroupList3Col(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groupList = await _blogService.GetBlogGroupList(3);

            return await Task.FromResult((IViewComponentResult)View("BlogGroupList3Col", groupList));
        }
    }
}
