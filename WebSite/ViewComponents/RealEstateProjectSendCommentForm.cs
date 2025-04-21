using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.ViewComponents
{
    public class RealEstateProjectSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateProjectCommentViewModel viewmodel = new AddNewRealEstateProjectCommentViewModel()
            {
                ProjectRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSendCommentForm", viewmodel));
        }
    }
}
