using WebSite.Core.Services;
using WebSite.DataLayer.Context;
using WebSite.DataLayer.Entities.About;
using WebSite.DataLayer.Entities.Address;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.Blog;
using WebSite.DataLayer.Entities.Contact;
using WebSite.DataLayer.Entities.Fact;
using WebSite.DataLayer.Entities.User;
using WebSite.DataLayer.Entities.Faq;
using WebSite.DataLayer.Entities.Language;
using WebSite.DataLayer.Entities.RealEstate;
using WebSite.DataLayer.Entities.Service;
using WebSite.DataLayer.Entities.Testimonial;

namespace WebSite.DataLayer.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection service)
        {
            //user 
            service.AddTransient<IGenericRepository<Permission>, GenericRepository<Permission>>();
            service.AddTransient<IGenericRepository<PermissionJoinRole>, GenericRepository<PermissionJoinRole>>();
            service.AddTransient<IGenericRepository<Users>, GenericRepository<Users>>();
            service.AddTransient<IGenericRepository<Role>, GenericRepository<Role>>();
            service.AddTransient<IGenericRepository<UserJoinRole>, GenericRepository<UserJoinRole>>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IPermissionService, PermissionService>();

            //real estate
            service.AddTransient<IGenericRepository<RealEstate>, GenericRepository<RealEstate>>();
            service.AddTransient<IGenericRepository<RealEstateGroup>, GenericRepository<RealEstateGroup>>();
            service.AddTransient<IGenericRepository<RealEstateUsageStatus>, GenericRepository<RealEstateUsageStatus>>();
            service.AddTransient<IGenericRepository<RealEstateStatus>, GenericRepository<RealEstateStatus>>();
            service.AddTransient<IGenericRepository<RealEstateRentPeriod>, GenericRepository<RealEstateRentPeriod>>();
            service.AddTransient<IGenericRepository<RealEstateOption>, GenericRepository<RealEstateOption>>();
            service.AddTransient<IGenericRepository<RealEstateJoinOption>, GenericRepository<RealEstateJoinOption>>();
            service.AddTransient<IGenericRepository<RealEstatePhoto>, GenericRepository<RealEstatePhoto>>();
            service.AddTransient<IGenericRepository<RealEstateComment>, GenericRepository<RealEstateComment>>();
            service.AddTransient<IGenericRepository<RealEstateType>, GenericRepository<RealEstateType>>();
            service.AddTransient<IGenericRepository<RealEstateAge>, GenericRepository<RealEstateAge>>();
            service.AddTransient<IGenericRepository<RealEstateBuildingDirection>, GenericRepository<RealEstateBuildingDirection>>();
            service.AddTransient<IRealEstateService, RealEstateService>();

            //real estate project
            service.AddTransient<IGenericRepository<RealEstateProject>, GenericRepository<RealEstateProject>>();
            service.AddTransient<IGenericRepository<RealEstateProjectPhoto>, GenericRepository<RealEstateProjectPhoto>>();
            service.AddTransient<IGenericRepository<RealEstateProjectStatus>, GenericRepository<RealEstateProjectStatus>>();
            service.AddTransient<IGenericRepository<RealEstateProjectComment>, GenericRepository<RealEstateProjectComment>>();

            //fact 
            service.AddTransient<IGenericRepository<Fact>, GenericRepository<Fact>>();
            service.AddTransient<IFactService, FactService>();

            //blog 
            service.AddTransient<IGenericRepository<Blog>, GenericRepository<Blog>>();
            service.AddTransient<IGenericRepository<BlogPhoto>, GenericRepository<BlogPhoto>>();
            service.AddTransient<IGenericRepository<BlogGroup>, GenericRepository<BlogGroup>>();
            service.AddTransient<IGenericRepository<BlogComment>, GenericRepository<BlogComment>>();
            service.AddTransient<IBlogService, BlogService>();

            //address 
            service.AddTransient<IGenericRepository<City>, GenericRepository<City>>();
            service.AddTransient<IAddressService, AddressService>();

            //testimonial 
            service.AddTransient<IGenericRepository<Testimonial>, GenericRepository<Testimonial>>();
            service.AddTransient<ITestimonialService, TestimonialService>();

            //upload service
            service.AddTransient<IUploadService, UploadService>();

            //setting 
            service.AddTransient<IGenericRepository<ContactMessage>, GenericRepository<ContactMessage>>();

            //faq 
            service.AddTransient<IGenericRepository<Faq>, GenericRepository<Faq>>();

            //team 
            service.AddTransient<IGenericRepository<Agent>, GenericRepository<Agent>>();
            service.AddTransient<IGenericRepository<AgentMessage>, GenericRepository<AgentMessage>>();
            service.AddTransient<IGenericRepository<AgentComment>, GenericRepository<AgentComment>>();
            service.AddTransient<IAgentService, AgentService>();

            //about 
            service.AddTransient<IGenericRepository<About>, GenericRepository<About>>();
            service.AddTransient<IAboutService, AboutService>();

            //service 
            service.AddTransient<IGenericRepository<Service>, GenericRepository<Service>>();
            service.AddTransient<IGenericRepository<ServiceComment>, GenericRepository<ServiceComment>>();
            service.AddTransient<IGenericRepository<ServiceGroup>, GenericRepository<ServiceGroup>>();
            service.AddTransient<IServiceItemService, ServiceItemService>();

            //contact 
            service.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
            service.AddTransient<IContactService, ContactService>();

            //contact 
            service.AddTransient<IGenericRepository<Language>, GenericRepository<Language>>();
            service.AddTransient<ILanguageService, LanguageService>();

           

            //site map
            service.AddTransient<ISiteMapService, SiteMapService>();

            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<ICookieValidatorService, CookieValidatorService>();
            service.AddTransient<MyContext>();
        }
    }
}