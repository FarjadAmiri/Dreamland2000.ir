using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumPayStatus
    {
        [Display(Name = "پرداخت نشده")]
        Unpaid = 1,
        [Display(Name = "پرداخت شده")]
        Paid = 2,
    }
}
