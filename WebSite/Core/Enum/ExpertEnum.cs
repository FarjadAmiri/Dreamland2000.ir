using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumExpertStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
    }

    public enum EnumLExpertGrade
    {
        [Display(Name = "کاردانی")]
        Associate = 1,
        [Display(Name = "کارشناسی")]
        Expert = 2,
        [Display(Name = "کارشناسی ارشد")]
        Masters = 3,
        [Display(Name = "دکتری")]
        Phd = 3
    }
}
