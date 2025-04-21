using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.User
{
    public class UpdateUserProfileByUserViewModel
    {
        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserRefId { get; set; }

        //personal info 
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? LastName { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        //gallery 
        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; }
    }
}
