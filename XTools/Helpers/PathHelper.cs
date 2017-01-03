using System;
using System.IO;
using System.Text.RegularExpressions;

namespace XTools.Helpers
{
    public static class PathHelper
    {
        //private string _separator;

        //public PathHelper(string separator)
        //{
        //    _separator = separator;
        //}

        //public string Combine(string path1, string path2)
        //{
        //    if (string.IsNullOrEmpty(path1) && string.IsNullOrEmpty(path2)) // both empty
        //        return "";
        //    if (string.IsNullOrEmpty(path1))
        //        return path2;
        //    if (path1.EndsWith(_separator))
        //        return path1 + path2;

        //    return path1 + _separator + path2;
        //}

        //public string GetFolderName(string path)
        //{
        //    var indexOfSeparator = path.LastIndexOf(_separator);
        //    if (indexOfSeparator < 0)
        //        return "";

        //    return path.Substring(0, indexOfSeparator);
        //}

        //public string RemoveLastFolder(string path)
        //{
        //    var index = path.LastIndexOf(_separator);
        //    if (index <= 0)
        //        return _separator;
        //    return path.Substring(0, index);
        //}

        //public string GetFileName(string path)
        //{
        //    // get the string from the last separator
        //    var indexOfSeparator = path.LastIndexOf(_separator);
        //    if (indexOfSeparator < 0)
        //        return path;

        //    return path.Substring(indexOfSeparator + 1);
        //}

        //public string GetFileNameWithoutExtension(string path)
        //{
        //    path = GetFileName(path); // only need the filename part
        //    // let's remove the extension
        //    int indexOfDot = path.LastIndexOf('.');
        //    if (indexOfDot == -1)
        //        return path;
        //    return path.Substring(0, indexOfDot);
        //}

        /// <summary>
        /// Returns the extension part of the filename
        /// </summary>
        /// <param name="path">full path of the file</param>
        /// <returns></returns>
        //public string GetFileExtension(string path)
        //{
        //    var fileName = GetFileName(path);
        //    // let's get the extension
        //    int indexOfDot = path.LastIndexOf('.');
        //    if (indexOfDot == -1)
        //        return ""; // no extension
        //    return path.Substring(indexOfDot);
        //}

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
