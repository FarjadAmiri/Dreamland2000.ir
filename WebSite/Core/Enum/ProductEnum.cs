using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumShowInLatestStatus
    {
        [Display(Name = "نمایش داده شود")]
        Show = 1,
        [Display(Name = "نمایش داده نشود")]
        DontShow = 2
    }

    public enum EnumNewStatus
    {
        [Display(Name = "محصول جدید است")]
        New = 1,
        [Display(Name = "محصول قدیمی است")]
        Old = 2
    }

    public enum EnumComingSoonStatus
    {
        [Display(Name = "محصول بزودی")]
        Soon = 1,
        [Display(Name = "محصول قدیمی است")]
        Exist = 2
    }

    public enum EnumExistStatus
    {
        [Display(Name = "محصول موجود است")]
        Exist = 1,
        [Display(Name = "محصول موجود نیست")]
        NotExist = 2
    }
}
