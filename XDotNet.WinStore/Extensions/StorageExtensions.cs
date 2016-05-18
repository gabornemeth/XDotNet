using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Linq;

namespace XDotNet.Extensions
{
    static class StorageExtensions
    {
        /// <summary>
        /// Opening existing storage file, or creating new if does not exist
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        //public async static Task<StorageFile> OpenOrCreateAsync(this StorageFolder folder, string name)
        //{
        //    var exists = await folder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists); // check whether the file exists
        //}

        /// <summary>
        /// Creates a new file and also creates directories along the path
        /// </summary>
        /// <param name="folder">The parent folder</param>
        /// <param name="path">The path of the file to be created in \dir1\dir2\file.txt format</param>
        /// <returns></returns>
        public async static Task<StorageFile> CreateFileWithPath(this IStorageFolder folder, string path, CreationCollisionOption options)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            
            var items = path.Split('\\');
            var currentFolder = folder;
            for (int i = 0; i < items.Length; i++)
            {
                if (string.IsNullOrEmpty(items[i]))
                    continue;

                if (i == items.Length - 1)
                {
                    // creates the file
                    return await currentFolder.CreateFileAsync(items[i], options);
                }
                else
                {
                    // cretes a folder along the path
                    currentFolder = await currentFolder.CreateFolderAsync(items[i], CreationCollisionOption.OpenIfExists);
                }
            }

            return null;
        }
    }
}
