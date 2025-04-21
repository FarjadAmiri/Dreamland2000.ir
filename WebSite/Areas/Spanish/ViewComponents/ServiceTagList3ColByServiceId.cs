using WebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebSite.DataLayer.Entities.Service;

namespace WebSite.Areas.Spanish.ViewComponents
{
    public class ServiceTagList3ColByServiceId : ViewComponent
    {

        private readonly IGenericRepository<Service> _serviceRepository;

        public ServiceTagList3ColByServiceId(IGenericRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var service = await _serviceRepository.GetById(id);

            return await Task.FromResult((IViewComponentResult)View("ServiceTagList3ColByServiceId", service));
        }
    }
}
