using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum SmsStatusEnum
    {
        [Display(Name = "ارسال شده")]
        Send = 1,
        [Display(Name = "ارسال نشده")]
        DontSend = 2,
       
    }
}
