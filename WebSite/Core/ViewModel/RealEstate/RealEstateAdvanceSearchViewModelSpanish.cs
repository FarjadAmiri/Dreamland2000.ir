using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateAdvanceSearchViewModelSpanish
    {
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Code")]
        public string? Code { get; set; }

        //count
        [Display(Name = "Room")]
        public int? RoomCount { get; set; }

        [Display(Name = "Bathroom")]
        public int? BathroomCount { get; set; }

        [Display(Name = "Parking")]
        public int? ParkingCount { get; set; }

        [Display(Name = "Property type")]
        public int? TypeRefId { get; set; }

        [Display(Name = "Property group")]
        public int? GroupRefId { get; set; }

        [Display(Name = "City")]
        public int? CityRefId { get; set; }

        //area
        [Display(Name = "Minimum price")]
        public int? MinPrice { get; set; }

        [Display(Name = "Maximum price")]
        public int? MaxPrice { get; set; }


        //area
        [Display(Name = "Minimum area")]
        public int? MinArea { get; set; }

        [Display(Name = "Maximum area")]
        public int? MaxArea { get; set; }

        public virtual ICollection<RealEstateOption>? OptionList { get; set; }
        public virtual ICollection<DataLayer.Entities.RealEstate.RealEstate>? RealEstateList { get; set; }
    }
}
