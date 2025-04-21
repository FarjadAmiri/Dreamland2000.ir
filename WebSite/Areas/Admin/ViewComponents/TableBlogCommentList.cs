using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class TableBlogCommentList : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<BlogComment> list)
        {
            return await Task.FromResult((IViewComponentResult)View("TableBlogCommentList", list));
        }


    }
}
