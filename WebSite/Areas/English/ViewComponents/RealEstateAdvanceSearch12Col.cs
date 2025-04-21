using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSite.Core.Services;
using WebSite.Core.ViewModel.RealEstate;

namespace WebSite.Areas.English.ViewComponents
{ public class RealEstateAdvanceSearch12Col : ViewComponent
    {
        private readonly IRealEstateService _realEstateService;
        private readonly IAddressService _addressService;
        private readonly IAgentService _agentService;

        public RealEstateAdvanceSearch12Col(IRealEstateService realEstateService, IAddressService addressService, IAgentService agentService)
        {
            _realEstateService = realEstateService;
            _addressService = addressService;
            _agentService = agentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            RealEstateAdvanceSearchViewModelEnglish viewmodel = new RealEstateAdvanceSearchViewModelEnglish();

            //group 
            var groupList = await _realEstateService.GetRealEstateGroupList(2);
            ViewBag.GroupRefId = new SelectList(groupList,
                "Id", "Title");

            //city
            var cityList = await _addressService.GetCityList(2);
            ViewBag.CityRefId = new SelectList(cityList,
                "Id", "Title");

            //type
            var typeList = await _realEstateService.GetRealEstateTypeList(2);
            ViewBag.TypeRefId = new SelectList(typeList,
                "Id", "Title");

           

            return await Task.FromResult((IViewComponentResult)View("RealEstateAdvanceSearch12Col", viewmodel));
        }
    }
}
