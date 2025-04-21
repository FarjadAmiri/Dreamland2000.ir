using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.Testimonial
{
    public class Testimonial
    {
        [Key]
        [Required()]
        public int Id { get; set; }

        [Display(Name = "نام مشتری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "خدمات")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Service { get; set; }

        [Display(Name = "پیام")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Message { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //date
        [Display(Name = "ثبت")]
        public DateTime? RegisterDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "بروزرسانی")]
        public DateTime? LastUpdate { get; set; } = MyDate.GetCurrentDate();

        //relation
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }
    }
}
