
namespace XDotNet.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Gets file size as string
        /// </summary>
        /// <param name="size">size as integer</param>
        /// <returns></returns>
        public static string GetSizeString(long size)
        {
            var units = new[] { "bytes", "KB", "MB", "GB" };
            int i = 0;
            double dSize = size;
            while (dSize > 1024)
            {
                dSize /= 1024;
                i++;
            }
            return string.Format("{0} {1}", dSize.ToString("F0"), units[i]);
        }
    }
}
