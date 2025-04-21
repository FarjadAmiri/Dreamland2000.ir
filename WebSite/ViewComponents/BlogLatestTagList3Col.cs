using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class BlogLatestTagList3Col : ViewComponent
    {

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
           

            return await Task.FromResult((IViewComponentResult)View("BlogLatestTagList3Col"));
        }
    }
}
