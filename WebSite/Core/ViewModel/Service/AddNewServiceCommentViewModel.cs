using System.ComponentModel.DataAnnotations;
using WebSite.Core.ViewModel.Global;

namespace WebSite.Core.ViewModel.Service
{
    public class AddNewServiceCommentViewModel:GoogleRecaptchaViewModel
    {
        [Display(Name = "نام ارسال کننده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Name { get; set; }

        [Display(Name = "تلفن تماس")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Tell { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        [Display(Name = "متن دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Comment { get; set; }

        //relation
        [Display(Name = "خدمات")]
        public int? ServiceRefId { get; set; }
    }
}
