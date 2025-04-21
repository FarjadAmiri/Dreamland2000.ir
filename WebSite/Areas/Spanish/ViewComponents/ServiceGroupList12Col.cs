using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class ServiceGroupList12Col : ViewComponent
    {

        private readonly IServiceItemService _serviceItemService;

        public ServiceGroupList12Col(IServiceItemService serviceItemService)
        {
            _serviceItemService = serviceItemService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

	        var groupList = await _serviceItemService.GetServiceGroupList(3);

            return await Task.FromResult((IViewComponentResult)View("ServiceGroupList12Col", groupList));
        }
    }
}
