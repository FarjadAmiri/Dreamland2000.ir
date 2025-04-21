using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.Account
{
    public class LoginBySmsViewModel
    {
        [Display(Name = "شناسه کاربر")]
        public int? UserRefId { get; set; }

        [Display(Name = "شماره موبایل")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "لطفا {0} معتبر وارد کنید")]
        public string? Mobile { get; set; }

        [Display(Name = "رمز یکبار مصرف")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Code { get; set; }
    }
}
