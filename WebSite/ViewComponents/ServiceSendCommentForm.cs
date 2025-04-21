using Microsoft.AspNetCore.Mvc;
using WebSite.Core.ViewModel.Service;
using WebSite.DataLayer.Entities.Service;


namespace WebSite.ViewComponents
{
    public class ServiceSendCommentForm : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            AddNewServiceCommentViewModel viewmodel = new AddNewServiceCommentViewModel()
            {
                ServiceRefId = id
            };

            return await Task.FromResult((IViewComponentResult)View("ServiceSendCommentForm", viewmodel));
        }
    }
}
