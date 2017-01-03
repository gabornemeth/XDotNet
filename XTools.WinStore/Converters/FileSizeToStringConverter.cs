using System;
using Windows.UI.Xaml.Data;
using XDotNet.Helpers;

namespace XDotNet.Converters
{
    public class FileSizeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var size = System.Convert.ToInt64(value);
            if (size == -1)
                return "?";

            return FileHelper.GetSizeString(size);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
