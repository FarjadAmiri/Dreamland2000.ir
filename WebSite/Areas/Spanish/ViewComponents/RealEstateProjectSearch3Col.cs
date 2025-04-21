using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateProjectSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RealEstateProjectSearchViewModelSpanish viewmodel = new RealEstateProjectSearchViewModelSpanish();

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSearch3Col", viewmodel));
        }
    }
}
