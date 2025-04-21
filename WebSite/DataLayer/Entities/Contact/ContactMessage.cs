using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.Contact
{
    public class ContactMessage
    {
        [Key]
        [Required()]
        public int Id { get; set; }

        //sender
        [Display(Name = "نام فرستنده")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderName { get; set; }

        //contact
        [Display(Name = "تلفن تماس")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderTell { get; set; }

        [Display(Name = "ایمیل فرستنده")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SenderEmail { get; set; }

        //message
        [Display(Name = "موضوع")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Subject { get; set; }

        [Display(Name = "پیام")]
        public string? Message { get; set; }

        //send date
        [Display(Name = "تاریخ ارسال")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        //setting
        [Display(Name = "وضعیت آرشیو")]
        public bool? IsArchive { get; set; } = false;

        [Display(Name = "وضعیت پاسخ")]
        public bool? IsAnswer { get; set; } = false;

        //relation
        //language
        [Display(Name = "زبان")]
        public int? LanguageRefId { get; set; }

        [ForeignKey("LanguageRefId")]
        public virtual Language.Language? Language { get; set; }



    }
}
