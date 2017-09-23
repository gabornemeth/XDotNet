using System;
using System.Text;

namespace XTools
{
    public class StringExtensions
    {
        public static string GetRandomString(int length)
        {
            var sb = new StringBuilder(length);
            var rnd = new Random(Environment.TickCount);
            for (int i = 0; i < length; i++)
                sb.Append((char)rnd.Next(0, 255));
            return sb.ToString();
        }

    }
}
