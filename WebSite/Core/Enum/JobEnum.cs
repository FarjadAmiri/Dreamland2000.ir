using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumJobStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
    }
}
