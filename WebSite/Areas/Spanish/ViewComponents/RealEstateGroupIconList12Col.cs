using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateGroupIconList12Col : ViewComponent
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateGroupIconList12Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var groupList = await _realEstateService.GetRealEstateGroupList(3);

            return await Task.FromResult((IViewComponentResult)View("RealEstateGroupIconList12Col", groupList));
        }
    }
}
