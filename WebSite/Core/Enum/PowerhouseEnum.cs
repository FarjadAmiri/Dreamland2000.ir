using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumPowerhouseType
    {
        [Display(Name = "گازی")]
        Gas = 1,
        [Display(Name = "بخار")]
        Steam = 2,
        [Display(Name = "ترکیبی")]
        Hybrid = 3
    }
}
