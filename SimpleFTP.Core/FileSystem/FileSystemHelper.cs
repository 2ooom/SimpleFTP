using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SimpleFTP.Core.FileSystem
{
    public class FileSystemHelper : IFileSystemHelper
    {
        public static string RootPath = ".";
        public static string DriveRootPath = "/";
        public static string ParentFolder = "..";
        public List<FilySystemItem> GetFolderContent(string path)
        {
            // looking for root path
            if (string.IsNullOrEmpty(path) || path == RootPath)
            {
                return Directory.GetLogicalDrives().Select(t => new FilySystemItem {Name = t, IsDrive = true}).ToList();
            }
            var curentDirectory  = new DirectoryInfo(path);
            var directories = curentDirectory.GetDirectories()
                .Select(t => new FilySystemItem
                {
                    Name = t.Name,
                    IsDirectory = true,
                });

            var files = curentDirectory.GetFiles()
                .Select(t => new FilySystemItem
                {
                    Name = t.Name,
                    Extension = t.Extension,
                    Size = GetFileSize(t.Length),
                });
            return directories.Union(files).ToList();
        }

        public static string GetFileSize(long bytesLength)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            var order = 0;
            while (bytesLength >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                bytesLength = bytesLength / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return string.Format("{0:0.##} {1}", bytesLength, sizes[order]);
        }
    }
}
