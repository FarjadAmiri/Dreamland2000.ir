using System.ComponentModel.DataAnnotations;
using WebSite.Core.Utility;

namespace WebSite.DataLayer.Entities.User
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        //account info 
        [Display(Name = "موبایل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Mobile { get; set; }

        [Display(Name = "آدرس ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Email { get; set; }

        //password
        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Password { get; set; }

        [Display(Name = "رمز یکبار مصرف")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? DisposablePassword { get; set; }

        //personal info 
        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? LastName { get; set; }

        //gallery  
        [Display(Name = "تصویر پروفایل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Photo { get; set; } = "default.jpg";

        //setting 
        [Display(Name = "توکن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? SerialNumber { get; set; } = MyGenerator.GenerateStringUniqCode();

        [Display(Name = "آخرین ورود")]
        public DateTimeOffset? LastLoggedIn { get; set; }

        [Display(Name = "وضعیت کاربر")] 
        public bool? IsActive { get; set; } = true;

        //date
        [Display(Name = "تاریخ عضویت")] 
        public DateTime? RegisterDate { get; set; } = MyDate.GetCurrentDate();

        [Display(Name = "آخرین بروزرسانی")]
        public DateTime? LastUpdate{ get; set; }= MyDate.GetCurrentDate();

        //active code 
        [Display(Name = "کد فعال سازی ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? EmailActiveCode { get; set; } = MyGenerator.GenerateStringUniqCode();

        [Display(Name = "وضعیت تایید ایمیل")] 
        public bool? IsEmailActive { get; set; } = false;

        [Display(Name = "کد فعال سازی موبایل ")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? MobileActiveCode { get; set; } = MyGenerator.Generate6DigitUniqCode();

        [Display(Name = "وضعیت تایید موبایل")] 
        public bool? IsMobileActive { get; set; } = false;

        //relation
        public virtual ICollection<UserJoinRole>? RoleList { get; set; }
    }
}
