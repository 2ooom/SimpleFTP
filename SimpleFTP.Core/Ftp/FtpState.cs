using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFTP.Core.Ftp
{
    internal class FtpState
    {
        public FtpState()
        {
            OperationException = null;
            OperationComplete = new ManualResetEvent(false);
        }

        public ManualResetEvent OperationComplete { get; private set; }

        public FtpWebRequest Request { get; set; }

        public string FileName { get; set; }

        public Exception OperationException { get; set; }

        public string StatusDescription { get; set; }
    }
}
