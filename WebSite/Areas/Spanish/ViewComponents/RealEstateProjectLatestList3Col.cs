using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateProjectLatestList3Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateProjectLatestList3Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var projectList = await _realEstateService.GetProjectLatestList(10,3);

            projectList = projectList.ToList();

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectLatestList3Col", projectList));
        }
    }
}
