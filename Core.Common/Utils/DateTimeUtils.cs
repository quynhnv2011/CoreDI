using System;
using System.Globalization;
using System.Web;

namespace Core.Common.Utils
{
    public class DateTimeUtils
    {
        public static DateTime EndOfDay(DateTime time)
        {             
            return new DateTime(time.Year, time.Month, time.Day, 23,59,59);
        }

        public static DateTime StartOfDay(DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);
        }

        public static DateTime ParseExact(string s, string format="dd/MM/yyyy")
        {
            try
            {
                DateTime temp;
                var ok = DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);
                return !ok ? DateTime.MinValue : temp;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
}
