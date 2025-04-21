using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class RealEstateCityList3Col : ViewComponent
    {

        private readonly IAddressService _addressService;

        public RealEstateCityList3Col(IAddressService addressService)
        {
            _addressService = addressService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var cityList = await _addressService.GetCityList(1);

            return await Task.FromResult((IViewComponentResult)View("RealEstateCityList3Col", cityList));
        }
    }
}
