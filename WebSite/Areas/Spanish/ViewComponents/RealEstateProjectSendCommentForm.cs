using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.RealEstate;


namespace WebSite.Areas.Spanish.ViewComponents
{
    public class RealEstateProjectSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewRealEstateProjectCommentViewModelSpanish viewmodel = new AddNewRealEstateProjectCommentViewModelSpanish()
            {
                ProjectRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("RealEstateProjectSendCommentForm", viewmodel));
        }
    }
}
