using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.ViewComponents
{
    public class RealEstateSearch3Col : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RealEstateSearchViewModel viewmodel = new RealEstateSearchViewModel();

            return await Task.FromResult((IViewComponentResult)View("RealEstateSearch3Col", viewmodel));
        }
    }
}
