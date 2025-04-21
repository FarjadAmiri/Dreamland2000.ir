using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Core.ViewModel.RealEstate
{
    public class RealEstateAdvanceSearchViewModel
    {
        [Display(Name = "عنوان")]
        public string? Title{ get; set; }

        [Display(Name = "کد")]
        public string? Code { get; set; }

        //count
        [Display(Name = "تعداد اتاق")]
        public int? RoomCount { get; set; }

        [Display(Name = "تعداد حمام")]
        public int? BathroomCount { get; set; }

        [Display(Name = "تعداد پارکینگ")]
        public int? ParkingCount { get; set; }
        
        [Display(Name = "نوع ملک")]
        public int? TypeRefId { get; set; }

        [Display(Name = "گروه")]
        public int? GroupRefId { get; set; }
        
        [Display(Name = "شهر")]
        public int? CityRefId { get; set; }

        //area
        [Display(Name = "حداقل قیمت")]
        public int? MinPrice { get; set; }

        [Display(Name = "حداکثر قیمت")]
        public int? MaxPrice { get; set; }


        //area
        [Display(Name = "حداقل مساحت")]
        public int? MinArea { get; set; }

        [Display(Name = "حداکثر مساحت")]
        public int? MaxArea { get; set; }

        public virtual ICollection<RealEstateOption>? OptionList { get; set; }
        public virtual ICollection<DataLayer.Entities.RealEstate.RealEstate>? RealEstateList { get; set; }
      
    }
}
