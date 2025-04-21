using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class BlogNewCommentList : ViewComponent
    {
        
        private readonly IBlogService _blogService;

        public BlogNewCommentList(IBlogService blogService)
        {
            _blogService = blogService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var newCompanyList = await _blogService.GetNotAcceptedBlogCommentList();

            return await Task.FromResult((IViewComponentResult)View("BlogNewCommentList", newCompanyList));
        }


    }
}
