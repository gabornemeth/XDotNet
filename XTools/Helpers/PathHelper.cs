using System;
using System.IO;
using System.Text.RegularExpressions;

namespace XTools.Helpers
{
    public static class PathHelper
    {
        /// <summary>
        /// "Increments" a file name.
        /// sample.txt becomes sample (1).txt, 
        /// sample (5).txt becomes sample (6).txt etc.
        /// </summary>
        /// <param name="path">The path needs to be incremented</param>
        /// <returns>The incremented path</returns>
        public static string Increment(string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var match = Regex.Match(fileName, @"(?<filename>\w+)\s*\((?<number>\d+)\)$");
            if (match.Success)
            {
                var number = Convert.ToInt32(match.Result("${number}"));
                fileName = string.Format("{0} ({1})", match.Result("${filename}"), number + 1);
            }
            else // does not end with number
                fileName = fileName + " (1)";

            return Path.Combine(Path.GetDirectoryName(path), fileName + Path.GetExtension(path));
        }
    }
}
