using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;
using WebSite.Core.ViewModel.Global;


namespace WebSite.Core.ViewModel.Contact
{
    public class ContactSendMessageViewModel : GoogleRecaptchaViewModel
    {

        [Display(Name = "تاریخ ارسال")]
        public DateTime? SendDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        //sender contact info
        [Display(Name = "تلفن تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "ایمیل فرستنده")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        //subject and message
        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Subject { get; set; }

        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Message { get; set; }

    }
}
