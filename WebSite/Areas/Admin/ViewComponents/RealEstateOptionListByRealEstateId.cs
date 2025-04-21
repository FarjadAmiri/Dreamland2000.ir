using Microsoft.AspNetCore.Mvc;
using WebSite.Core.Services;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class RealEstateOptionListByRealEstateId : ViewComponent
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateOptionListByRealEstateId(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var optionList = await _realEstateService.GetOptionListByRealEstateId(id);

            return await Task.FromResult((IViewComponentResult)View("RealEstateOptionListByRealEstateId", optionList));
        }


    }
}
