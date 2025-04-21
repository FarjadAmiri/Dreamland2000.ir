using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.ViewComponents
{
    public class RealEstateProjectSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RealEstateProjectSearchViewModel viewmodel = new RealEstateProjectSearchViewModel();

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSearch3Col", viewmodel));
        }
    }
}
