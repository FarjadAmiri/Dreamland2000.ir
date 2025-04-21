using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.DataLayer.Entities.Address;

namespace WebSite.DataLayer.Entities.RealEstate
{
    public class RealEstateProject
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        [Display(Name = "عنوان کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? ShortTitle { get; set; }

        [Display(Name = "کد")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Code { get; set; }

        [Display(Name = "برچسب")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tags { get; set; }

        [Display(Name = "توضیحات")]
        public string? Summary { get; set; }

        //option
        [Display(Name = "متراژ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Area { get; set; }

        [Display(Name = "اتاق")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Room { get; set; }

        [Display(Name = "حمام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Bathroom { get; set; }

        //price
        [Display(Name = "قیمت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Price { get; set; }
        
        //location
        [Display(Name = "لوکیشن")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Location { get; set; }

        [Display(Name = "نقشه")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Iframe { get; set; }

       
       

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //date
        [Display(Name = "تاریخ ثبت")]
        public DateTime? RegisterDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "بروزرسانی")]
        public DateTime? LastUpdate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "بازدید")]
        public int? Visit { get; set; } = 0;

        //relation 
        //status
        [Display(Name = "وضعیت پروژه")]
        public int? StatusRefId { get; set; }

        [ForeignKey("StatusRefId")]
        public virtual RealEstateProjectStatus? Status { get; set; }

        //city
        [Display(Name = "شهر")]
        public int? CityRefId { get; set; }

        [ForeignKey("CityRefId")]
        public virtual City? City { get; set; }

        //agent
        [Display(Name = "کارشناس")]
        public int? AgentRefId { get; set; }

        [ForeignKey("AgentRefId")]
        public virtual Agent.Agent? Agent { get; set; }

        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<RealEstateProjectComment>? CommentList { get; set; }
        public virtual ICollection<RealEstateProjectPhoto>? PhotoList { get; set; }
    }
}
