using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Blog;


namespace WebSite.Areas.Spanish.ViewComponents
{
    public class BlogSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            BlogSendCommentViewModelSpanish comment = new BlogSendCommentViewModelSpanish()
            {
                BlogRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("BlogSendCommentForm", comment));
        }
    }
}
