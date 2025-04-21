using System.ComponentModel.DataAnnotations;
using WebSite.Core.ViewModel.Global;


namespace WebSite.Core.ViewModel.Account
{
    public class LoginViewModelEnglish : GoogleRecaptchaViewModel
    {
        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(15, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string? Mobile { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
