using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{ public class RealEstateSearchByCity12Col : ViewComponent
    {

        private readonly IAddressService _addressService;

        public RealEstateSearchByCity12Col(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var cityList = await _addressService.GetCityList(3);

            return await Task.FromResult((IViewComponentResult)View("RealEstateSearchByCity12Col", cityList));
        }
    }
}
