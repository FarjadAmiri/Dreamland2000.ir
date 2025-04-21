using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateProjectSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RealEstateProjectSearchViewModelEnglish viewmodel = new RealEstateProjectSearchViewModelEnglish();

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSearch3Col", viewmodel));
        }
    }
}
