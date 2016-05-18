using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDotNet.Localization
{
    public class DefaultLocale : ILocale
    {
        public string Get(string text)
        {
            return text;
        }

        public string Get(string format, params object[] arguments)
        {
            return string.Format(format, arguments);
        }
    }
}
