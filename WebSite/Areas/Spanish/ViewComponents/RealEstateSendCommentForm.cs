using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateCommentViewModelSpanish viewmodel = new AddNewRealEstateCommentViewModelSpanish()
            {
                PropertyRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateSendCommentForm", viewmodel));
        }
    }
}
