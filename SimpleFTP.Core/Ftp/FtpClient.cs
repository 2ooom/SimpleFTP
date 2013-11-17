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
        public event Action<List<FilySystemItem>, string> ListingDirectoryReceived;

        protected virtual void OnListingDirectoryReceived(List<FilySystemItem> fileItems, string path)
        {
            Action<List<FilySystemItem>, string> handler = ListingDirectoryReceived;
            if (handler != null) handler(fileItems, path);
        }

        public void Connect(string userName, string password, string serverUri, bool enableSsl = true)
        {
            if (serverUri.EndsWith("/"))
            {
                serverUri = serverUri.Substring(0, serverUri.Length - 1);
            }
            ServerUri = string.Concat("ftp://", serverUri);
            UserName = userName;
            Password = password;
            EnableSsl = enableSsl;
        }

        public void GetDirectoryListing(string currentPath = "/")
        {
            var request = (FtpWebRequest)WebRequest.Create(ServerUri);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            var ftpstate = new FtpState{Request = request};
            request.BeginGetResponse(GetDirectoryListingCallback, ftpstate);
        }

        private void GetDirectoryListingCallback(IAsyncResult asyncResult)
        {
            var state = (FtpState) asyncResult.AsyncState;
            var content = new List<FilySystemItem>();
            using (var stream = state.Request.EndGetResponse(asyncResult))
            {
                using (var streamReader = new StreamReader(stream.GetResponseStream()))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var name = streamReader.ReadLine();
                        content.Add(new FilySystemItem {Name = name});
                    }
                }
                OnListingDirectoryReceived(content, state.Request.RequestUri.AbsolutePath);
            }
        }
    }
}
