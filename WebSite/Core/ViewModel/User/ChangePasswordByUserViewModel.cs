using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.User
{
    public class ChangePasswordByUserViewModel
    {
        [Display(Name = "شناسه")]
        public int UserRefId { get; set; }

        [Display(Name = "کلمه عبور قدیمی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبور جدید مغایرت دارند")]
        public string? ConfirmPassword { get; set; }
    }
}
