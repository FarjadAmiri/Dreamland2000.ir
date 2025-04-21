using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateLatestList12Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateLatestList12Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var realEstateList = await _realEstateService.GetRealEstateLatestList(6,3);
            
            realEstateList = realEstateList.ToList();

            //photo list 
            foreach (var item in realEstateList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            return await Task.FromResult((IViewComponentResult)View("RealEstateLatestList12Col", realEstateList));
        }
    }
}
