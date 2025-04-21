using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.Blog
{
    public class Blog
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Title { get; set; }

        [Display(Name = "برچسب")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tags { get; set; }

        [Display(Name = "خلاصه")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Summary { get; set; }

        [Display(Name = "متن کامل")]
        public string? Content { get; set; }

        [Display(Name = "نویسنده")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Author { get; set; }

        //gallery
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //date
        [Display(Name = "تاریخ ثبت")]
        public DateTime? RegisterDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "تاریخ مقاله")]
        public DateTime? BlogDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "تاریخ بروزرسانی")]
        public DateTime? LastUpdate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "بازدید")]
        public int? Visit { get; set; } = 0;

        //relation 
        [Display(Name = "گروه")]
        public int? GroupRefId { get; set; }

        [ForeignKey("GroupRefId")]
        public virtual BlogGroup? Group { get; set; }

        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }

        public virtual ICollection<BlogComment>? CommentList { get; set; }
        public virtual ICollection<BlogPhoto>? PhotoList { get; set; }

    }
}
