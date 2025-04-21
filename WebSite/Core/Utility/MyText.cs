using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace WebSite.Core.Utility
{
    public class MyText
    {
        public static string RemoveHtmlTag(string inputString)
        {
            var outputString = Regex.Replace(inputString, "<.*?>", String.Empty);
            outputString = Regex.Replace(outputString, "&nbsp;", " ");
            
            return outputString;
        }

        public static string CleanTitle(string title)
        {
            if (!title.IsNullOrEmpty())
            {
                string cleanTitle = title.Replace("ي", "ی").Replace("_", " ").Replace("-", " ").Replace("&quot;", "").Replace("&nbsp;", "").Replace("&zwnj;","").Trim();
                return cleanTitle;
            }

            return title;
        }

        public static string CleanMobile(string mobile)
        {
            if (!mobile.IsNullOrEmpty())
            {
                string cleanMobile = mobile.Replace(" ", "").Replace("-", "").Replace("_", "").Trim();
                cleanMobile = cleanMobile.PersianToEnglishChar();
                return cleanMobile;
            }

            return mobile;
        }

        public static string CleanTell(string tell)
        {
            if (!tell.IsNullOrEmpty())
            {
                string cleanTell = tell.Replace(" ", "").Trim();
                cleanTell = cleanTell.PersianToEnglishChar();
                return cleanTell;
            }

            return tell;
        }
    }
}
