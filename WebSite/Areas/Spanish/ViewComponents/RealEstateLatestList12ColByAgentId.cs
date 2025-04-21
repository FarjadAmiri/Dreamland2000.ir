using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateLatestList12ColByAgentId : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateLatestList12ColByAgentId(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

	        var realEstateList = await _realEstateService.GetRealEstateListByAgentId(id);

            realEstateList = realEstateList.ToList();

            //photo list 
            foreach (var item in realEstateList)
            {
                var photoList = await _realEstateService.GetPhotoListByRealEstateId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            return await Task.FromResult((IViewComponentResult)View("RealEstateLatestList12ColByAgentId", realEstateList));
        }
    }
}
