using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Blog
{
    public class BlogGroup
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "حداکثر طول مجاز برای {0} {1} کاراکتر می باشد")]
        public string? Title { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }

        [Display(Name = "تعداد")]
        public int? Count { get; set; }

        [Display(Name = "وضعیت نمایش")]
        public int? VisibleStatusId { get; set; }

        //relations 
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<Blog>? BlogList { get; set; }
        
    }
}
