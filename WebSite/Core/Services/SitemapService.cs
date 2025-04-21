using WebSite.Core.Utility;
using WebSite.Core.ViewModel.SiteMap;

namespace WebSite.Core.Services
{
    public interface ISiteMapService
    {
        Task<string> GetSiteMap();
    }
    public class SiteMapService : ISiteMapService
    {
       
        private readonly IBlogService _blogService;
        private readonly IAgentService _agentService;
        private readonly IServiceItemService _serviceItemService;
        private readonly IRealEstateService _realEstateService;


        public SiteMapService(IBlogService blogService, IAgentService agentService, IServiceItemService serviceItemService, IRealEstateService realEstateService)
        {
            _blogService = blogService;
            _agentService = agentService;
            _serviceItemService = serviceItemService;
            _realEstateService = realEstateService;
        }

        public async Task<string> GetSiteMap()
        {

            var siteMapBuilder = new MySiteMap();
            DateTime lastUpdate = Convert.ToDateTime("2025-03-29");

            //home 
            siteMapBuilder.AddUrl(url:"https://dreamland2000.ir",modified:MyDate.GetCurrentDate(), changeFrequency:ChangeFrequency.Daily, priority: 1.0);
            
            //blog 
            var blogListPersian = await _blogService.GetBlogList(1);
            blogListPersian = blogListPersian.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/blog", modified: blogListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in blogListPersian)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/blog/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Yearly, priority: 0.5);
            }

            var blogListEnglish = await _blogService.GetBlogList(2);
            blogListEnglish = blogListEnglish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/blog", modified: blogListEnglish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in blogListEnglish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/blog/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Yearly, priority: 0.5);
            }

            var blogListSpanish = await _blogService.GetBlogList(3);
            blogListSpanish = blogListSpanish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/blog", modified: blogListSpanish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in blogListSpanish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/blog/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Yearly, priority: 0.5);
            }

            //service 
            var serviceListPersian = await _serviceItemService.GetServiceList(1);
            serviceListPersian = serviceListPersian.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/service", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in serviceListPersian)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/service/" + item.Id, modified: lastUpdate , changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            var serviceListEnglish = await _serviceItemService.GetServiceList(2);
            serviceListEnglish = serviceListEnglish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/service", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in serviceListEnglish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/service/" + item.Id, modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            var serviceListSpanish = await _serviceItemService.GetServiceList(3);
            serviceListSpanish = serviceListSpanish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/service", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in serviceListSpanish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/service/" + item.Id, modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            //agent 
            var agentListPersian = await _agentService.GetAgentList(1);
            agentListPersian = agentListPersian.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/agent", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in agentListPersian)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/agent/" + item.Id, modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            var agentListEnglish = await _agentService.GetAgentList(2);
            agentListEnglish = agentListEnglish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/agent", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in agentListEnglish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/agent/" + item.Id, modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            var agentListSpanish = await _agentService.GetAgentList(3);
            agentListSpanish = agentListSpanish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/agent", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            foreach (var item in agentListSpanish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/agent/" + item.Id, modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.5);
            }

            //real estate 
            var realEstateListPersian = await _realEstateService.GetRealEstateList(1);
            realEstateListPersian = realEstateListPersian.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/grid", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/list", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in realEstateListPersian)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }

            var realEstateListEnglish = await _realEstateService.GetRealEstateList(2);
            realEstateListEnglish = realEstateListEnglish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/grid", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/list", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in realEstateListEnglish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }

            var realEstateListSpanish = await _realEstateService.GetRealEstateList(3);
            realEstateListSpanish = realEstateListSpanish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/grid", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/list", modified: realEstateListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in realEstateListSpanish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }


            //project 
            var projectListPersian = await _realEstateService.GetProjectList(1);
            projectListPersian = projectListPersian.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/project", modified: projectListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/project/grid", modified: projectListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/project/list", modified: projectListPersian.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in projectListPersian)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/realestate/project/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }

            var projectListEnglish = await _realEstateService.GetRealEstateList(2);
            projectListEnglish = projectListEnglish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/project", modified: projectListEnglish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/project/grid", modified: projectListEnglish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/project/list", modified: projectListEnglish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in projectListEnglish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/realestate/project/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }

            var projectListSpanish = await _realEstateService.GetRealEstateList(3);
            projectListSpanish = projectListSpanish.ToList();
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/project", modified: projectListSpanish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/project/grid", modified: projectListSpanish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/project/list", modified: projectListSpanish.First().LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            foreach (var item in projectListSpanish)
            {
                siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/realestate/project/" + item.Id, modified: item.LastUpdate, changeFrequency: ChangeFrequency.Daily, priority: 0.5);
            }

            //about 
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/about", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/about", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/about", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);

            //contact 
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/contact", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/en/contact", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);
            siteMapBuilder.AddUrl(url: "https://dreamland2000.ir/es/contact", modified: lastUpdate, changeFrequency: ChangeFrequency.Monthly, priority: 0.4);

           
            //generate ----------------------------------------------------------------
            string xml = siteMapBuilder.ToString();
            return xml;
            //-------------------------------------------------------------------------
        }
    }
}
