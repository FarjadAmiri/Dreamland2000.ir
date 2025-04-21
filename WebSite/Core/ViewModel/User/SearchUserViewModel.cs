using System.ComponentModel.DataAnnotations;
using WebSite.DataLayer.Entities.User;

namespace WebSite.Core.ViewModel.User
{
    public class SearchUserViewModel
    {
        [Display(Name = "نام کاربر")]
        public string? Name { get; set; }

        [Display(Name = "شماره موبایل")]
        public string? Mobile { get; set; }

        [Display(Name = "آدرس ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "نوع جستجو")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفا {0} را انتخاب نمایید")]
        public int? UserSearchTypeId { get; set; }

        [Display(Name = "عبارت جستجو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? SearchText { get; set; }

        public IEnumerable<Users>? UserList { get; set; }
    }
}
