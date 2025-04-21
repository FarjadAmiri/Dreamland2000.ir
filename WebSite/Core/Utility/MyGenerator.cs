using System;

namespace WebSite.Core.Utility
{
    public class MyGenerator
    {
        public static string GenerateStringUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string Generate4DigitUniqCode()
        {
            int _min = 1111;
            int _max = 9999;
            Random random = new Random();
            return random.Next(_min, _max).ToString();
        }

        public static string Generate5DigitUniqCode()
        {
            int _min = 11111;
            int _max = 99999;
            Random random = new Random();
            return random.Next(_min, _max).ToString();
        }

        public static string Generate6DigitUniqCode()
        {
            int _min = 111111;
            int _max = 999911;
            Random random = new Random();
            return random.Next(_min, _max).ToString();
        }
    }
}
