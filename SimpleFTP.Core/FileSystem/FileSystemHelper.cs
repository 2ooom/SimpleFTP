using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleFTP.Core.FileSystem
{
    public class FileSystemHelper : IFileSystemHelper
    {
        public List<FileSystemItem> GetFolderContent(string path)
        {
            // looking for root path
            if (string.IsNullOrEmpty(path))
            {
                return Directory.GetLogicalDrives().Select(t => new FileSystemItem {Name = t, IsDrive = true}).ToList();
            }
            var curentDirectory  = new DirectoryInfo(path);
            var directories = curentDirectory.GetDirectories()
                .Select(t => new FileSystemItem
                {
                    Name = t.Name,
                    IsDirectory = true,
                });

            var files = curentDirectory.GetFiles()
                .Select(t => new FileSystemItem
                {
                    Name = t.Name,
                    Extension = t.Extension,
                    Size = GetFileSize(t.Length),
                });
            var result = directories.Union(files).ToList();
            if (Directory.GetParent(path) != null)
            {
                result.Insert(0, new FileSystemItem { IsParentNavigation = true });
            }
            return result;
        }

        public string TrimPath(string path)
        {
            return path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
        public string GetFileSize(long bytesLength)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            var order = 0;
            while (bytesLength >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                bytesLength = bytesLength / 1024;
            }
            return string.Format("{0:0.##} {1}", bytesLength, sizes[order]);
        }
    }
}
