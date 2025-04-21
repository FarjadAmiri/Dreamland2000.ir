using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.ViewComponents
{
    public class RealEstateLatestList3Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateLatestList3Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var realEstateList = await _realEstateService.GetRealEstateLatestList(10,1);
            
            realEstateList = realEstateList.ToList();

            return await Task.FromResult((IViewComponentResult)View("RealEstateLatestList3Col", realEstateList));
        }
    }
}
