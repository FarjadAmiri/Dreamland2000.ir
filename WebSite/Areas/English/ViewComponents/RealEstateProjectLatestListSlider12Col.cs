using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateProjectLatestListSlider12Col : ViewComponent
    {

        private readonly IRealEstateService _realEstateService;

        public RealEstateProjectLatestListSlider12Col(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var projectList = await _realEstateService.GetProjectLatestList(20,2);

            projectList = projectList.ToList();

            //photo list 
            foreach (var item in projectList)
            {
                var photoList = await _realEstateService.GetPhotoListByProjectId(item.Id);
                item.PhotoList = photoList.ToList();
            }

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectLatestListSlider12Col", projectList));
        }
    }
}
