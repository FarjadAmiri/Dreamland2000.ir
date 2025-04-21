using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableBlogList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<Blog> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableBlogList", list));
        }


    }
}
