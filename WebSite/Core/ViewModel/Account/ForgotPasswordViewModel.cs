using System.ComponentModel.DataAnnotations;
using WebSite.Core.ViewModel.Global;


namespace WebSite.Core.ViewModel.Account
{
    public class ForgotPasswordViewModel : GoogleRecaptchaViewModel
    {
        [Display(Name = "شماره موبایل")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "لطفا {0} معتبر وارد کنید")]
        public string? Mobile { get; set; }
    }
}
