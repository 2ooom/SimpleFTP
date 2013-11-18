using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SimpleFTP.Core.FileSystem;

namespace SimpleFTP.Core.Ftp
{
    public class FtpClient : IFtpClient
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ServerUri { get; private set; }
        public bool EnableSsl { get; private set; }
        public event Action<List<FileSystemItem>, string> ListingDirectoryReceived;
        public event Action<Exception> Eror;

        protected virtual void OnEror(Exception exception)
        {
            Action<Exception> handler = Eror;
            if (handler != null) handler(exception);
        }

        protected virtual void OnListingDirectoryReceived(List<FileSystemItem> fileItems, string path)
        {
            Action<List<FileSystemItem>, string> handler = ListingDirectoryReceived;
            if (handler != null) handler(fileItems, path);
        }

        public void Connect(string userName, string password, string serverUri, bool enableSsl = true)
        {
            if (serverUri.EndsWith("/"))
            {
                serverUri = serverUri.Substring(0, serverUri.Length - 1);
            }
            ServerUri = new UriBuilder(Uri.UriSchemeFtp, serverUri).ToString();
            UserName = userName;
            Password = password;
            EnableSsl = enableSsl;
        }

        public void GetDirectoryListing(string currentPath = "/")
        {
            var request = (FtpWebRequest)WebRequest.Create(ServerUri);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            var ftpstate = new FtpState{Request = request};
            request.BeginGetResponse(GetDirectoryListingCallback, ftpstate);
        }

        private void GetDirectoryListingCallback(IAsyncResult asyncResult)
        {
            var state = (FtpState) asyncResult.AsyncState;
            var content = new List<FileSystemItem>();
            try
            {
                using (var stream = state.Request.EndGetResponse(asyncResult))
                {
                    using (var streamReader = new StreamReader(stream.GetResponseStream()))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var name = streamReader.ReadLine();
                            var ext = Path.GetExtension(name);
                            content.Add(new FileSystemItem {Name = name, Extension = ext, IsDirectory = string.IsNullOrEmpty(ext)});
                        }
                    }
                    OnListingDirectoryReceived(content, state.Request.RequestUri.AbsolutePath);
                }
            }
            catch (Exception exception)
            {
                OnEror(exception);
            }
        }
    }
}
