using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDotNet
{
    public class Converter
    {
        public static float ToSingle(object obj, float defaultValue)
        {
            try
            {
                if (obj == null)
                    return defaultValue;

                string s = obj.ToString();
                System.Globalization.NumberFormatInfo i = new System.Globalization.NumberFormatInfo();
                if (s.IndexOf(".") >= 0) i.NumberDecimalSeparator = ".";
                else i.NumberDecimalSeparator = ",";
                return System.Convert.ToSingle(s, i);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static float ToSingle(object obj)
        {
            return ToSingle(obj, 0.0f);
        }
    }
}
