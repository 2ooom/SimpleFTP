﻿using System;
using System.Collections.Generic;
using SimpleFTP.Core.FileSystem;

namespace SimpleFTP.Core.Ftp
{
    public interface IFtpClient
    {
        void Connect(string userName, string password, string host, bool enableSsl = true);
        void GetDirectoryListing(string currentPath = "/");

        event Action<List<FileSystemItem>, string> ListingDirectoryReceived;
        event Action<Exception> Eror;
    }
}
