using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumAdsStatus
    {
        [Display(Name = "در انتظار تایید")]
        New = 1,
        [Display(Name = "تایید شده")]
        Accepted = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
        [Display(Name = "لغو شده")]
        Canceled = 4,
        [Display(Name = "منقضی شده")]
        Expire = 5,
    }

    public enum EnumAdsPayType
    {
        [Display(Name = "پرداخت آفلاین")]
        OfflinePayment = 1,

        [Display(Name = "پرداخت آنلاین")]
        OnlinePayment = 2,
    }

}
