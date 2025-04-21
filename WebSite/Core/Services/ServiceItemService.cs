using WebSite.DataLayer.Entities.Service;

namespace WebSite.Core.Services
{

    public interface IServiceItemService
    {
        Task<IEnumerable<Service>> GetServiceList(int group = -1,int language=-1);
        Task<IEnumerable<Service>> GetServiceList(int language=-1);
     
        Task<bool> VisitPlusServiceByServiceId(int id);

        //group
        Task<IEnumerable<ServiceGroup>> GetServiceGroupList(int language=-1);
        
        //comment
        Task<IEnumerable<ServiceComment>> GetCommentListByServiceId(int id);
    }


    public class ServiceItemService : IServiceItemService
    {
        private readonly IGenericRepository<Service> _serviceRepository;
        private readonly IGenericRepository<ServiceComment> _serviceCommentRepository;
        private readonly IGenericRepository<ServiceGroup> _serviceGroupRepository;


        public ServiceItemService(IGenericRepository<Service> serviceRepository, IGenericRepository<ServiceGroup> serviceGroupRepository, IGenericRepository<ServiceComment> serviceCommentRepository)
        {
            _serviceRepository = serviceRepository;
            _serviceGroupRepository = serviceGroupRepository;
            _serviceCommentRepository = serviceCommentRepository;
        }

        public async Task<IEnumerable<Service>> GetServiceList(int group = -1, int language = -1)
        {
            var serviceList = await _serviceRepository.Get(
                includes: "Group",
                orderBy: q => q.OrderBy(d => d.Group).ThenBy(s=>s.Sort));

            //language filter
            if (language != -1)
            {
                serviceList = serviceList.Where(l => l.LanguageRefId == language);
            }

            //group filter
            if (group != -1)
            {
                serviceList = serviceList.Where(g => g.GroupRefId == group);
            }

            serviceList = serviceList.ToList();

            return serviceList;
        }
        
   

        public async Task<IEnumerable<Service>> GetServiceList(int language = -1)
        {
            var serviceList = await _serviceRepository.Get(
                includes: "Group",
                orderBy: q => q.OrderBy(d => d.Group).ThenBy(s=>s.Sort));

            //language filter
            if (language != -1)
            {
                serviceList = serviceList.Where(l => l.LanguageRefId == language);
            }

            return serviceList;
        }

      
        public async Task<bool> VisitPlusServiceByServiceId(int id)
        {
            var service = await _serviceRepository.GetById(id);
            if (service.Visit == null || service.Visit < 0)
            {
                service.Visit = 0;
            }

            service.Visit += 1;

            await _serviceRepository.Update(service);

            return true;
        }
       
        public async Task<IEnumerable<ServiceGroup>> GetServiceGroupList(int language = -1)
        {
            var groupList = await _serviceGroupRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                groupList = groupList.Where(l => l.LanguageRefId == language);
            }

            return groupList;
        }

        public async Task<IEnumerable<ServiceComment>> GetCommentListByServiceId(int id)
        {
            var commentList = await _serviceCommentRepository.Get(
                l => l.ServiceRefId == id,
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            return commentList;
        }
    }
}
