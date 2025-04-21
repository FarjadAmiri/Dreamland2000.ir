using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumMarriedStatus
    {
        [Display(Name = "مجرد")]
        Single = 1,
        [Display(Name = "متاهل")]
        Married = 2,
        [Display(Name = "سایر")]
        Other = 3,
    }

   

    public enum EnumUserSearchType
    {
        [Display(Name = "جستجوی شماره موبایل")]
        ByMobile = 1,
        [Display(Name = "جستجوی آدرس ایمیل")]
        ByEmail = 2,
        [Display(Name = "جستجوی نام و نام خانوادگی")]
        ByName = 3,
    }

    public enum LanguageEnum
    {
        [Display(Name = "فارسی")]
        Fa = 1,
        [Display(Name = "انگلیسی")]
        En = 2
    }

    public enum EnumUserStatus
    {
        [Display(Name = "فعال آست")]
        Active = 1,
        [Display(Name = "غیر فعال است")]
        DeActive = 2
    }

    public enum EnumBannerType
    {
        [Display(Name = "بنر تکی")]
        One = 1,
        [Display(Name = "بنر دو تایی")]
        Two = 2,
        [Display(Name = "بنر سه تایی")]
        Three = 3
    }

    public enum EnumVisibleStatus
    {
        [Display(Name = "نمایش داده شود")]
        Visible = 1,
        [Display(Name = "نمایش داده نشود")]
        InVisible = 2
    }

    public enum EnumCommentSendStatus
    {
        [Display(Name = "ارسال نظر فعال باشد")]
        Allow = 1,
        [Display(Name = "ارسال نظر غیر فعال باشد")]
        DontAllow = 2
    }

    public enum EnumAcceptStatus
    {
        [Display(Name = "تایید شده است")]
        Accept = 1,
        [Display(Name = "تایید نشده است")]
        NotAccept = 2,

    }

    public enum EnumEmailSendStatus
    {
        [Display(Name = "ارسال شده است")]
        Sended = 1,
        [Display(Name = "ارسال نشده است")]
        DontSend = 2,

    }

    public enum EnumGender
    {
        [Display(Name = "آقا")]
        Male = 1,
        [Display(Name = "خانم")]
        Female = 2,
    }

    public enum EnumDeleteStatus
    {
        [Display(Name = "حذف شده")]
        Deleted = 1,
        [Display(Name = "حذف نشده")]
        NotDeleted = 2,
    }
}
