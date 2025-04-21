using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Blog;


namespace WebSite.ViewComponents
{
    public class BlogSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            BlogSendCommentViewModel comment = new BlogSendCommentViewModel()
            {
                BlogRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("BlogSendCommentForm", comment));
        }
    }
}
