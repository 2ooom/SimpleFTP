using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFTP.Core.FileSystem
{
    public class FileSystemItem
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsParentNavigation { get; set; }
        public bool IsDrive { get; set; }
    }
}
