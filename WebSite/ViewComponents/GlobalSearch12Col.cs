using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Global;

namespace WebSite.ViewComponents
{
    public class GlobalSearch12Col : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            GlobalSearchViewModel viewmodel = new GlobalSearchViewModel();

            return await Task.FromResult((IViewComponentResult)View("GlobalSearch12Col", viewmodel));
        }
    }
}
