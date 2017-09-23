using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTools.Localization
{
    public interface ILocale
    {
        string Get(string text);
        string Get(string format, params object[] arguments);
    }

    public class Locale
    {
        public static ILocale Implementation { get; set; }

        public static string Get(string text)
        {
            return Implementation.Get(text);
        }

        public static string Get(string format, params object[] arguments)
        {
            return Implementation.Get(format, arguments);
        }
    }
}
