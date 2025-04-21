using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumBannerSize
    {
        [Display(Name = "دو ستونه")]
        S2 = 2,
        [Display(Name = "سه ستونه")]
        S3 = 3,
        [Display(Name = "چهار ستونه")]
        S4 = 4,
        [Display(Name = "شش ستونه")]
        S6 = 6,
        [Display(Name = "هشت ستونه")]
        S8 = 8,
        [Display(Name = "نه ستونه")]
        S9 = 9,
        [Display(Name = "دوازده ستونه")]
        S12 = 12,
    }
  
}
