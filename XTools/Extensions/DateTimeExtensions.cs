//
// DateTimeExtensions.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2016, Gabor Nemeth
//
using System;

namespace XTools.Extensions
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
