using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.Areas.English.ViewComponents
{
    public class RealEstateSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateCommentViewModelEnglish viewmodel = new AddNewRealEstateCommentViewModelEnglish()
            {
                RealEstateRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateSendCommentForm", viewmodel));
        }
    }
}
