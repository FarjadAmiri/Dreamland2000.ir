using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.User;

namespace WebSite.Core.ViewModel.Account
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "شناسه")]
        public int? UserRefId { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }


        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبور جدید مغایرت دارند")]
        public string? ConfirmPassword { get; set; }

        //relation
        [Display(Name = "کاربر")]
        public Users? User { get; set; }
    }
}
