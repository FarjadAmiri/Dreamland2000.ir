using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Areas.English.ViewComponents
{
    public class ServiceLatestList3Col : ViewComponent
    {
        
        private readonly IServiceItemService _serviceItemService;

        public ServiceLatestList3Col(IServiceItemService serviceItemService)
        {
            _serviceItemService = serviceItemService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var serviceList = await _serviceItemService.GetServiceList(2);

            //random change latest ads
            Random rand1 = new Random();
            serviceList = serviceList.OrderBy(c => rand1.Next()).ToList();


            return await Task.FromResult((IViewComponentResult)View("ServiceLatestList3Col", serviceList));
        }
    }
}
