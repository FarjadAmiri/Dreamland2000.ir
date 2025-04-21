using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Service;


namespace WebSite.Areas.Spanish.ViewComponents
{
    public class ServiceSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewServiceCommentViewModelSpanish viewmodel = new AddNewServiceCommentViewModelSpanish()
            {
                ServiceRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("ServiceSendCommentForm", viewmodel));
        }
    }
}
