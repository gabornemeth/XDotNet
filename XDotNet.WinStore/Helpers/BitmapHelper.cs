using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace XDotNet.Extensions
{
    public static class BitmapHelper
    {
        async public static Task<BitmapImage> BytesToBitmapImage(byte[] bytes)
        {
            var image = new BitmapImage();
            // workaround: MemoryStream must be created with publicly visible buffer, but this constructor is not available in WinRT
            using (MemoryStream ms = new MemoryStream(bytes.Length))
            {
                await ms.WriteAsync(bytes, 0, bytes.Length);
                ms.Position = 0;
                var randomStream = ms.AsRandomAccessStream();
                await image.SetSourceAsync(randomStream);
            }
            return image;
        }
    }
}
