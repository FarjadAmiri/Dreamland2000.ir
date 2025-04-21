using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
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

	        var blogList = await _blogService.GetBlogLatestList(3,2);

            blogList = blogList.ToList();

            foreach (var item in blogList!)
            {
                //comment list
                var commentList = await _blogService.GetAcceptedBlogCommentListByBlogId(item.Id);
                item.CommentList = commentList.ToList();
            }

            return await Task.FromResult((IViewComponentResult)View("BlogLatestList12Col", blogList));
        }
    }
}
