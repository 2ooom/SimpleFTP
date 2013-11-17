using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFTP.Core.Tests
{
    public class FakeRequestCreator : IWebRequestCreate
    {
        public WebRequest Create(Uri uri)
        {
            //var ftpRequest = new FtpWebRequest()
            return null;
        }
    }
}
