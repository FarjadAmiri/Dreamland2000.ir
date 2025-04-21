using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;

namespace WebSite.Core.Utility
{
    public static class MyDate
    {
        public static string GregorianToPersian(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static string GetCurrentPersianDate()
        {
            string strPersianDate = GregorianToPersian(DateTime.Now);
            return strPersianDate;
        }
        public static DateTime GetCurrentDate()
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
            DateTime cstDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone);
            return cstDate;
            //return DateTime.Now;
        }


        public static string PersianToEnglishChar(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9',
                ['0'] = '0',
                ['1'] = '1',
                ['2'] = '2',
                ['3'] = '3',
                ['4'] = '4',
                ['5'] = '5',
                ['6'] = '6',
                ['7'] = '7',
                ['8'] = '8',
                ['9'] = '9',
                ['/'] = '/',
                ['-'] = '-',
                ['_'] = '_',
                ['+'] = '+',
                [','] = ',',
                ['~'] = '~',
                ['!'] = '!',
                ['#'] = '#',
                ['$'] = '$',
                ['%'] = '%',
                ['^'] = '^',
                ['&'] = '&',
                ['*'] = '*',
                ['('] = '(',
                [')'] = ')',
                ['@'] = '@',
                ['.'] = '.',
                ['،'] = '،',

            };

            if (persianStr.IsNullOrEmpty())
            {
                return persianStr;
            }

            foreach (var item in persianStr)
            {
                persianStr = persianStr.Replace(item, LettersDictionary[item]);
            }
            return persianStr;
        }

        public static string EnglishToPersianChar(this string englishStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['0'] = '۰',
                ['1'] = '۱',
                ['2'] = '۲',
                ['3'] = '۳',
                ['4'] = '۴',
                ['5'] = '۵',
                ['6'] = '۶',
                ['7'] = '۷',
                ['8'] = '۸',
                ['9'] = '۹',
                ['/'] = '/'
            };
            foreach (var item in englishStr)
            {
                englishStr = englishStr.Replace(item, LettersDictionary[item]);
            }
            return englishStr;
        }
        public static DateTime PersianToGregorian(string str)
        {
            try
            {
                string[] strPersianDate = str.Split('/');
                PersianCalendar pc2 = new PersianCalendar();
                DateTime dt2 = new DateTime(int.Parse(strPersianDate[0]), int.Parse(strPersianDate[1]), int.Parse(strPersianDate[2]), pc2);
                return dt2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static int MonthNameToMonthNumber(string monthName)
        {

            int month = 0;
            switch (monthName)
            {
                case "فروردین":
                    month = 1;
                    break;
                case "فروردين":
                    month = 1;
                    break;
                //-----------------
                case "اردیبهشت":
                    month = 2;
                    break;
                case "ارديبهشت":
                    month = 2;
                    break;
                //-----------------
                case "خرداد":
                    month = 3;
                    break;
                //-----------------
                case "تیر":
                    month = 4;
                    break;
                case "تير":
                    month = 4;
                    break;
                //-----------------
                case "مرداد":
                    month = 5;
                    break;
                //-----------------
                case "شهريور":
                    month = 6;
                    break;

                case "شهریور":
                    month = 6;
                    break;
                //-----------------
                case "مهر":
                    month = 7;
                    break;
                //-----------------
                case "آبان":
                    month = 8;
                    break;
                //-----------------
                case "آذر":
                    month = 9;
                    break;
                //-----------------
                case "دی":
                    month = 10;
                    break;
                case "دي":
                    month = 10;
                    break;
                //-----------------
                case "بهمن":
                    month = 11;
                    break;
                //-----------------
                case "اسفند":
                    month = 12;
                    break;
            }

            //if (month == 0)
            //{
            //    var currentPersianDate = GetCurrentPersianDate();
            //    var array = currentPersianDate.Split("/");

            //}

            return month;
        }
        public static string GetYears(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date).ToString();
        }


        public static string GetMonthName(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            string strMonthName = "";
            int intDay = pc.GetDayOfMonth(date);
            int intMonth = pc.GetMonth(date);
            int intYear = pc.GetYear(date);

            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
            }

            return strMonthName;
        }

        public static int GetDayOfMonth(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            int intDay = pc.GetDayOfMonth(date);
            int intMonth = pc.GetMonth(date);
            int intYear = pc.GetYear(date);
            return intDay;
        }

    }
}
