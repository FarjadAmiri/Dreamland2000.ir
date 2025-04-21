using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RealEstateSearchViewModelSpanish viewmodel = new RealEstateSearchViewModelSpanish();

            return await Task.FromResult((IViewComponentResult)View("RealEstateSearch3Col", viewmodel));
        }
    }
}
