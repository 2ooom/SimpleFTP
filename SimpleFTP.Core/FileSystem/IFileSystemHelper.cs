using System.Collections.Generic;

namespace SimpleFTP.Core.FileSystem
{
    public interface IFileSystemHelper
    {
        List<FileSystemItem> GetFolderContent(string path);
        string TrimPath(string path);
        string GetFileSize(long bytesLength);
    }
}
