using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateTypeList3Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateTypeList3Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var typeList = await _realEstateService.GetRealEstateTypeList(2);

            return await Task.FromResult((IViewComponentResult)View("RealEstateTypeList3Col", typeList));
        }
    }
}
