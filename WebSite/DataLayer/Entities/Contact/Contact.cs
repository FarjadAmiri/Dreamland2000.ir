using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Contact
{
    public class Contact
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        [Display(Name = "خلاصه")]
        [MaxLength(2000, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Summary { get; set; }
       
        //contact
        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Address { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Tell { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Email { get; set; }

        [Display(Name = "وب سایت")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Website { get; set; }

        //social
        [Display(Name = "تلگرام")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Telegram { get; set; }

        [Display(Name = "اینستاگرام")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Instagram { get; set; }

        [Display(Name = "واتس آپ")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? WhatsApp { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Photo { get; set; }

        //relation
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }
    }
}
