using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumSalonStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
        [Display(Name = "لغو شده")]
        Cancel = 4,
    }

    public enum EnumBeautySampleStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
        [Display(Name = "لغو شده")]
        Cancel = 4,
    }

    public enum EnumBeautyProductStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
        [Display(Name = "لغو شده")]
        Cancel = 4,
    }

}
