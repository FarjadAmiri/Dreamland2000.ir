using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumComplexStatus
    {
        [Display(Name = "در انتظار تایید")]
        WaitForAccept = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
    }


    public enum EnumComplexType
    {
        [Display(Name = "مجتمع تجاری")]
        Commercial = 1,
        [Display(Name = "مجتمع اداری")]
        Official = 2,
        [Display(Name = "مجتمع تجاری اداری")]
        OfficeCommercial = 3,
        [Display(Name = "سایر")]
        Other = 4,
    }

}
