using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstatePhoto
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        //gallery 
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //setting 
        [Display(Name = "تاریخ بارگذاری'")]
        public DateTime? UploadDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; } = 1;

        //relation 
        [Display(Name = "ملک")]
        public int? RealEstateRefId { get; set; }

        [ForeignKey("RealEstateRefId")]
        public virtual RealEstate? RealEstate { get; set; }
    }
}
