using System.Collections.Generic;

namespace SimpleFTP.Core.FileSystem
{
    public interface IFileSystemHelper
    {
        List<FilySystemItem> GetFolderContent(string path);
    }
}
