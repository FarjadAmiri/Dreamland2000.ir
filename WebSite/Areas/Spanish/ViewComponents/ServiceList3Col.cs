using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class ServiceList3Col : ViewComponent
    {
        
        private readonly IServiceItemService _serviceItemService;

        public ServiceList3Col(IServiceItemService serviceItemService)
        {
            _serviceItemService = serviceItemService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var serviceList = await _serviceItemService.GetServiceList(3);
            


            return await Task.FromResult((IViewComponentResult)View("ServiceList3Col", serviceList));
        }
    }
}
