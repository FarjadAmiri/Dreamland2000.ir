using WebSite.DataLayer.Entities.Blog;
using WebSite.DataLayer.Entities.Contact;
using WebSite.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using WebSite.DataLayer.Entities.About;
using WebSite.DataLayer.Entities.Address;
using WebSite.DataLayer.Entities.Agent;
using WebSite.DataLayer.Entities.Fact;
using WebSite.DataLayer.Entities.Faq;
using WebSite.DataLayer.Entities.Service;
using WebSite.DataLayer.Entities.RealEstate;
using WebSite.DataLayer.Entities.Testimonial;


namespace WebSite.DataLayer.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
           
        }
        //user 
        public DbSet<Role> Role { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserJoinRole> UserJoinRole { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionJoinRole> PermissionJoinRole { get; set; }


        
        //real estate
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<RealEstateGroup> RealEstateGroup { get; set; }
        public DbSet<RealEstateUsageStatus> RealEstateUsageStatus { get; set; }
        public DbSet<RealEstateRentPeriod> RealEstateRentPeriod { get; set; }
        public DbSet<RealEstateOption> RealEstateOption { get; set; }
        public DbSet<RealEstateJoinOption> RealEstateJoinOption { get; set; }
        public DbSet<RealEstatePhoto> RealEstatePhoto { get; set; }
        public DbSet<RealEstateType> RealEstateType { get; set; }
        public DbSet<RealEstateComment> RealEstateComment { get; set; }
        public DbSet<RealEstateAge> RealEstateAge { get; set; }
        public DbSet<RealEstateBuildingDirection> RealEstateBuildingDirection { get; set; }

        //real estate project
        public DbSet<RealEstateProject> RealEstateProject { get; set; }
        public DbSet<RealEstateProjectPhoto> RealEstateProjectPhoto { get; set; }
        public DbSet<RealEstateProjectComment> RealEstateProjectComment { get; set; }
        public DbSet<RealEstateProjectStatus> RealEstateProjectStatus { get; set; }

        //service
        public DbSet<Service> Service{ get; set; }
        public DbSet<ServiceComment> ServiceComment{ get; set; }
        public DbSet<ServiceGroup> ServiceGroup{ get; set; }

        //about 
        public DbSet<About> About { get; set; }

        //testimonial 
        public DbSet<Testimonial> Testimonial { get; set; }

        //agent 
        public DbSet<Agent> Agent{ get; set; }
        public DbSet<AgentMessage> AgentMessage{ get; set; }
        public DbSet<AgentComment> AgentComment{ get; set; }

        //contact 
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactMessage> ContactMessage { get; set; }

        //fact 
        public DbSet<Fact> Fact { get; set; }
       

        //faq 
        public DbSet<Faq> Faq { get; set; }

        //blog 
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogPhoto> BlogPhoto { get; set; }
        public DbSet<BlogGroup> BlogGroup { get; set; }
        public DbSet<BlogComment> BlogComment { get; set; }
        
        //address
        public DbSet<City> City { get; set; }
        
    }
}
