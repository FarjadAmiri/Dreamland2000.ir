using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateProjectCityList3Col : ViewComponent
    {

        private readonly IAddressService _addressService;

        public RealEstateProjectCityList3Col(IAddressService addressService)
        {
            _addressService = addressService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var cityList = await _addressService.GetCityList(1);

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectCityList3Col", cityList));
        }
    }
}
