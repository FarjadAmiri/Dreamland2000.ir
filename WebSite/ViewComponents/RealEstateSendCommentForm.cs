using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.ViewComponents
{
    public class RealEstateSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateCommentViewModel viewmodel = new AddNewRealEstateCommentViewModel()
            {
                RealEstateRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateSendCommentForm", viewmodel));
        }
    }
}
