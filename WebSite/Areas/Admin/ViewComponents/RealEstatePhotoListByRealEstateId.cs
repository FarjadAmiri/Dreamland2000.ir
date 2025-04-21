using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class RealEstatePhotoListByRealEstateId : ViewComponent
    {        
        
        private readonly IRealEstateService _realEstateService;

        public RealEstatePhotoListByRealEstateId(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var photoList = await _realEstateService.GetPhotoListByRealEstateId(id);           

			return await Task.FromResult((IViewComponentResult)View("RealEstatePhotoListByRealEstateId", photoList));
        }
    }
}
