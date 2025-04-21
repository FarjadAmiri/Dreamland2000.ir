using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateGroupList3Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateGroupList3Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var groupList = await _realEstateService.GetRealEstateGroupList(2);

            return await Task.FromResult((IViewComponentResult)View("RealEstateGroupList3Col", groupList));
        }
    }
}
