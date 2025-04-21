using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Address
{
    public class City
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Photo { get; set; }

        //location
        [Display(Name = "لوکیشن")]
        [MaxLength(2000, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Location { get; set; }

        //setting
        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }

        [Display(Name = "وضعیت نمایش")]
        public bool? IsVisible { get; set; }
     

        //relations 
        [Display(Name = "استان")]
        public int? ProvinceRefId { get; set; }

        [ForeignKey("ProvinceRefId")]
        public virtual Province? Province { get; set; }

        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }


    }
}
