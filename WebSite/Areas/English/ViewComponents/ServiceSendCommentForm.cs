using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Service;


namespace WebSite.Areas.English.ViewComponents
{
    public class ServiceSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewServiceCommentViewModelEnglish viewmodel = new AddNewServiceCommentViewModelEnglish()
            {
                ServiceRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("ServiceSendCommentForm", viewmodel));
        }
    }
}
