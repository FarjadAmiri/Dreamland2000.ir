using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class AddNewRealEstateByAdminViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Title { get; set; }

        [Display(Name = "Code")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Code { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Tags { get; set; }

        [Display(Name = "Description")]
        public string? Summary { get; set; }

        //price
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public float? Price { get; set; }

        [Display(Name = "Unit charge")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? UnitCharge { get; set; }

        [Display(Name = "Garbage cost")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? GarbageCost { get; set; }

        //area
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Please enter {0}.")]
        public int? Area { get; set; }

        [Display(Name = "Land Area")]
        public int? LandArea { get; set; }

        [Display(Name = "Base Area")]
        public int? BaseArea { get; set; }

        [Display(Name = "Terrace Area")]
        public int? TerraceArea { get; set; }

        [Display(Name = "Yard Area")]
        public int? YardArea { get; set; }

        //building
        [Display(Name = "Energy Grade")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? EnergyGrade { get; set; }

        [Display(Name = "Build Year")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? BuildYear { get; set; }

        [Display(Name = "Floor")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Floor { get; set; }

        [Display(Name = "Unit")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Unit { get; set; }

        [Display(Name = "Room")]
        public int? RoomCount { get; set; } = 1;

        [Display(Name = "Bathroom")]
        public int? BathroomCount { get; set; } = 1;

        [Display(Name = "Parking")]
        public int? ParkingCount { get; set; } = 1;

        [Display(Name = "Cooling System")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? CoolingSystem { get; set; }

        [Display(Name = "Heating System")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? HeatingSystem { get; set; }

        //location
        [Display(Name = "Location")]
        [MaxLength(500, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Location { get; set; }

        [Display(Name = "Iframe")]
        [MaxLength(2000, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Iframe { get; set; }

        

        //relation 
        //group
        [Display(Name = "Group")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? GroupRefId { get; set; }

        [Display(Name = "Direction")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? DirectionRefId { get; set; }

        //status
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? StatusRefId { get; set; }

        //usage
        [Display(Name = "Usage Status")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? UsageRefId { get; set; }

        //rent period
        [Display(Name = "Rent Period")]
        public int? RentPeriodRefId { get; set; }
        
        

        //type
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? TypeRefId { get; set; }

        //city
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select {0}.")]
        public int? CityRefId { get; set; }

        //agent
        [Display(Name = "Agent")]
        public int? AgentRefId { get; set; }

        [Display(Name = "Language")]
        public int? LanguageRefId { get; set; }

        [Display(Name = "Language Title")]
        public string? LanguageEnglishTitle { get; set; }

        [Display(Name = "Language Short Title")]
        public string? LanguageShortTitle { get; set; }
    }
}
