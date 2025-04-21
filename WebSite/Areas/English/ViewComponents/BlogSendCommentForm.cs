using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Blog;


namespace WebSite.Areas.English.ViewComponents
{
    public class BlogSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            BlogSendCommentViewModelEnglish comment = new BlogSendCommentViewModelEnglish()
            {
                BlogRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("BlogSendCommentForm", comment));
        }
    }
}
