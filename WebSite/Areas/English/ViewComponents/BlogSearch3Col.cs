using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Blog;

namespace WebSite.Areas.English.ViewComponents
{
    public class BlogSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            BlogSearchViewModel viewmodel = new BlogSearchViewModel();

            return await Task.FromResult((IViewComponentResult)View("BlogSearch3Col", viewmodel));
        }
    }
}
