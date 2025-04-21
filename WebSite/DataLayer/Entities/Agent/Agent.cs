using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSite.DataLayer.Entities.Agent
{
    public class Agent
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "مسئولیت")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Responsibility { get; set; }

        [Display(Name = "بیوگرافی")]
        public string? Summary { get; set; }


        //contact
        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Address { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; } = 1;

        [Display(Name = "تعداد بازدید")]
        public int? Visit { get; set; } = 0;

        //relation
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<RealEstate.RealEstate>? RealEstateList { get; set; }
        public virtual ICollection<AgentMessage>? MessageList { get; set; }
    }
}
