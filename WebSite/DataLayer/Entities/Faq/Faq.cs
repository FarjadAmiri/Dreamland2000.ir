using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.DataLayer.Entities.Faq
{
   public class Faq
    {
        [Key]
        [Required()]
        public int Id { get; set; }
        
        [Display(Name = "پرسش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Question { get; set; }

        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Answer { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int? Sort { get; set; }

        //relation
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }


    }
}
