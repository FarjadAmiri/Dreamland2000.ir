using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Service
{
    public class Service
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }


        [Display(Name = "برچسب")]
        [MaxLength(2000, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Tags { get; set; }

        [Display(Name = "خلاصه")]
        public string? Summary { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Photo { get; set; }

        //setting
        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }


        [Display(Name = "تعداد")]
        public int? Count { get; set; }

        [Display(Name = "آمار بازدید")]
        public int? Visit { get; set; }

        //relation 
        [Display(Name = "گروه")]
        public int? GroupRefId { get; set; }

        [ForeignKey("GroupRefId")]
        public virtual ServiceGroup? Group { get; set; }

        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<ServiceComment>? CommentList { get; set; }

    }
}
