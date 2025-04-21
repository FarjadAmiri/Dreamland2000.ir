using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
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

	        var projectList = await _realEstateService.GetProjectLatestList(10,1);

            projectList = projectList.ToList();

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectLatestList3Col", projectList));
        }
    }
}
