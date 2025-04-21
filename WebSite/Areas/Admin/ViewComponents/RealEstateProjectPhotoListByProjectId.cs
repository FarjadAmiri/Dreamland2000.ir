using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Admin.ViewComponents
{
    public class RealEstateProjectPhotoListByProjectId : ViewComponent
    {        
        
        private readonly IRealEstateService _realEstateService;

        public RealEstateProjectPhotoListByProjectId(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var photoList = await _realEstateService.GetPhotoListByProjectId(id);           

			return await Task.FromResult((IViewComponentResult)View("RealEstateProjectPhotoListByProjectId", photoList));
        }
    }
}
