using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.ViewModel.User
{
    public class UpdateUserProfileByAdminViewModel
    {
        [Display(Name = "شناسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserRefId { get; set; }


        [Display(Name = "شماره موبایل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$0", ErrorMessage = "لطفا {0} معتبر وارد کنید")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
		public string? Mobile { get; set; }

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
