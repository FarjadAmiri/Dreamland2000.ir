using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateProjectStatusList3Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateProjectStatusList3Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
	        var statusList = await _realEstateService.GetProjectStatusList(3);

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectStatusList3Col", statusList));
        }
    }
}
