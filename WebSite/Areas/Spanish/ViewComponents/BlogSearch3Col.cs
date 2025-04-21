using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Blog;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class BlogSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            BlogSearchViewModelSpanish viewmodel = new BlogSearchViewModelSpanish();

            return await Task.FromResult((IViewComponentResult)View("BlogSearch3Col", viewmodel));
        }
    }
}
