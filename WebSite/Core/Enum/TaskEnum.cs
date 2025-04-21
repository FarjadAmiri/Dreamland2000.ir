using System.ComponentModel.DataAnnotations;

namespace WebSite.Core.Enum
{
    public enum EnumTaskStatus
    {
        [Display(Name = "تسک جدید")]
        New = 1,
        [Display(Name = "تسک بسته شده")]
        Close = 1,
    }

    public enum EnumTaskPriority
    {
        [Display(Name = "اولویت کم")]
        Low = 1,
        [Display(Name = "اولویت عادی")]
        Medium = 2,
        [Display(Name = "اولویت زیاد")]
        High = 3,
    }

    public enum EnumReferDeadlineYear
    {
        [Display(Name = "1399")]
        Y1399 = 1,
        [Display(Name = "1400")]
        Y1400 = 2,
    }

    public enum EnumReferDeadlineMonth
    {
        [Display(Name = "فروردین")]
        M1 = 1,
        [Display(Name = "اردیبهشت")]
        M2 = 2,
        [Display(Name = "خرداد")]
        M3 = 3,
        [Display(Name = "تیر")]
        M4 = 4,
        [Display(Name = "مرداد")]
        M5 = 5,
        [Display(Name = "شهریور")]
        M6 = 6,
        [Display(Name = "مهر")]
        M7 = 7,
        [Display(Name = "آبان")]
        M8 = 8,
        [Display(Name = "آذر")]
        M9 = 9,
        [Display(Name = "دی")]
        M10 = 10,
        [Display(Name = "بهمن")]
        M11 = 11,
        [Display(Name = "اسفند")]
        M12 = 12,
    }

    public enum EnumReferDeadlineDay
    {
        [Display(Name = "1")]
        D1 = 1,
        [Display(Name = "2")]
        D2 = 2,
        [Display(Name = "3")]
        D3 = 3,
        [Display(Name = "4")]
        D4 = 4,
        [Display(Name = "5")]
        D5 = 5,
        [Display(Name = "6")]
        D6 = 6,
        [Display(Name = "7")]
        D7 = 7,
        [Display(Name = "8")]
        D8 = 8,
        [Display(Name = "9")]
        D9 = 9,
        [Display(Name = "10")]
        D10 = 10,
        [Display(Name = "11")]
        D11 = 11,
        [Display(Name = "12")]
        D12 = 12,
        [Display(Name = "13")]
        D13 = 13,
        [Display(Name = "14")]
        D14 = 14,
        [Display(Name = "15")]
        D15 = 15,
        [Display(Name = "16")]
        D16 = 16,
        [Display(Name = "17")]
        D17 = 17,
        [Display(Name = "18")]
        D18 = 18,
        [Display(Name = "19")]
        D19 = 19,
        [Display(Name = "20")]
        D20 = 20,
        [Display(Name = "21")]
        D21 = 21,
        [Display(Name = "22")]
        D22 = 22,
        [Display(Name = "23")]
        D23 = 23,
        [Display(Name = "24")]
        D24 = 24,
        [Display(Name = "25")]
        D25 = 25,
        [Display(Name = "26")]
        D26 = 26,
        [Display(Name = "27")]
        D27 = 27,
        [Display(Name = "28")]
        D28 = 28,
        [Display(Name = "29")]
        D29 = 29,
        [Display(Name = "30")]
        D30 = 30,
        [Display(Name = "31")]
        D31 = 31,
    }

}
