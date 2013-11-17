using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFTP.Core
{
    public class FtpClient
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ServerUri { get; private set; }
        public bool EnableSsl { get; private set; }

        public FtpClient(string userName, string password, string serverUri, bool enableSsl = true)
        {
            ServerUri = serverUri;
            UserName = userName;
            Password = password;
            EnableSsl = enableSsl;
        }

        public List<string> GetDirectoryListing(string currentPath = null)
        {
            var request = (FtpWebRequest)WebRequest.Create(ServerUri);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            var response = (FtpWebResponse)request.GetResponse();
            var folders = new List<string>();
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        folders.Add(streamReader.ReadLine());
                    }
                }
            }
            return folders;
        }
    }
}
