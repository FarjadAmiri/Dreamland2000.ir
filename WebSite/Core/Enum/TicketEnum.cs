using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumTicketStatus
    {
        [Display(Name = "تیکت جدید")]
        New = 1,
        [Display(Name = "پاسخ مشتری")]
        CustomerAnswer = 2,
        [Display(Name = "پاسخ مدیر")]
        AdminAnswer = 3,
        [Display(Name = "در حال بررسی")]
        Process = 4,
        [Display(Name = "بسته شده")]
        Closed = 5,
    }

    public enum TicketPriorityEnum
    {
        [Display(Name = "اولویت کم")]
        Low = 1,
        [Display(Name = "اولویت عادی")]
        Medium = 2,
        [Display(Name = "اولویت زیاد")]
        High = 3,
    }
}
