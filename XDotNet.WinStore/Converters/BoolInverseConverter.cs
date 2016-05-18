using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace XDotNet.Converters
{
    public class BoolInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !System.Convert.ToBoolean(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !System.Convert.ToBoolean(value);
        }
    }

}
