using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDotNet.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            var daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            return new DateTime(dt.Year, dt.Month, daysInMonth);
        }
    }
}
