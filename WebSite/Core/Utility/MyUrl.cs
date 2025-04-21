using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebSite.Core.Utility
{

    public static class MyUrl
    {
        public static string ResolveSubjectForUrl(string subject)
        {
            return Regex.Replace(Regex.Replace(subject, "[^\\w]", "-"), "[-]{2,}", "-");
        }

    }
}
