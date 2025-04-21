using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateProjectSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateProjectCommentViewModelEnglish viewmodel = new AddNewRealEstateProjectCommentViewModelEnglish()
            {
                ProjectRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSendCommentForm", viewmodel));
        }
    }
}
