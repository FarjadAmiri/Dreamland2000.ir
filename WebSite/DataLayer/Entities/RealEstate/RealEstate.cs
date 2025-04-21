using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.Address;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstate
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        [Display(Name = "Code")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Code { get; set; }

        [Display(Name = "Tags")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tags { get; set; }

        [Display(Name = "Description")]
        public string? Summary { get; set; }

        //price
        [Display(Name = "Price")]
        public float? Price { get; set; } = 0;

        [Display(Name = "Unit charge")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? UnitCharge { get; set; }

        [Display(Name = "Garbage cost")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? GarbageCost { get; set; }

        //area
        [Display(Name = "Area")] public int? Area { get; set; } = 0;
        
        [Display(Name = "Land Area")]
        public int? LandArea { get; set; } = 0;

        [Display(Name = "Base Area")]
        public int? BaseArea { get; set; } = 0;

        [Display(Name = "Terrace Area")]
        public int? TerraceArea { get; set; } = 0;

        [Display(Name = "Yard Area")]
        public int? YardArea { get; set; } = 0;


        //building
        [Display(Name = "Energy Grade")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? EnergyGrade { get; set; }

        [Display(Name = "Build Year")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? BuildYear { get; set; }

        [Display(Name = "Floor")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Floor { get; set; }

        [Display(Name = "Unit")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Unit { get; set; }

        [Display(Name = "Room")]
        public int? RoomCount { get; set; } = 0;

        [Display(Name = "Bathroom")]
        public int? BathroomCount { get; set; } = 0;

        [Display(Name = "Parking")]
        public int? ParkingCount { get; set; } = 0;

        [Display(Name = "Cooling System")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? CoolingSystem { get; set; }

        [Display(Name = "Heating System")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? HeatingSystem { get; set; }
        
        //location
        [Display(Name = "Location")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Location { get; set; }

        [Display(Name = "IFrame")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Iframe { get; set; }

        //gallery
        [Display(Name = "Photo")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //date
        [Display(Name = "Register Date")]
        public DateTime? RegisterDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "Last Update")]
        public DateTime? LastUpdate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "Visit")]
        public int? Visit { get; set; } = 0;

        //relation 
        //status
        [Display(Name = "Status")]
        public int? StatusRefId { get; set; }

        [ForeignKey("StatusRefId")]
        public virtual RealEstateStatus? Status { get; set; }

        //usage
        [Display(Name = "Usage")]
        public int? UsageRefId { get; set; }

        [ForeignKey("UsageRefId")]
        public virtual RealEstateUsageStatus? Usage { get; set; }

        //rent period
        [Display(Name = "Rent Period")]
        public int? RentPeriodRefId { get; set; }

        [ForeignKey("RentPeriodRefId")]
        public virtual RealEstateRentPeriod? RentPeriod { get; set; }


        //group
        [Display(Name = "Group")]
        public int? GroupRefId { get; set; }

        [ForeignKey("GroupRefId")]
        public virtual RealEstateGroup? Group { get; set; }

        //group
        [Display(Name = "Type")]
        public int? TypeRefId { get; set; }

        [ForeignKey("TypeRefId")]
        public virtual RealEstateType? Type { get; set; }

        //city
        [Display(Name = "City")]
        public int? CityRefId { get; set; }

        [ForeignKey("CityRefId")]
        public virtual City? City { get; set; }

        //agent
        [Display(Name = "Direction")]
        public int? DirectionRefId { get; set; }

        [ForeignKey("DirectionRefId")]
        public virtual RealEstateBuildingDirection? Direction { get; set; }

        //agent
        [Display(Name = "Agent")]
        public int? AgentRefId { get; set; }

        [ForeignKey("AgentRefId")]
        public virtual Agent.Agent? Agent { get; set; }

        //language
        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<RealEstateComment>? CommentList { get; set; }
        public virtual ICollection<RealEstatePhoto>? PhotoList { get; set; }
        public virtual ICollection<RealEstateJoinOption>? OptionList { get; set; }
    }
}
