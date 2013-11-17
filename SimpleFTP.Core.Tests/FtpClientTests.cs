using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleFTP.Core.Ftp;

namespace SimpleFTP.Core.Tests
{
    [TestClass]
    public class FtpClientTests
    {
        private const string UserName = "User Name";
        private const string Password = "strongpassword";
        private const string ServerUri = "ftp://someserver";
        protected FtpClient Client;

        [TestInitialize]
        public void Initialize()
        {
            Client = new FtpClient();
            Client.Connect(UserName, Password, ServerUri);
        }

        [TestMethod]
        public void Instance_is_initialized_correctly_by_default()
        {
            Assert.IsNotNull(Client);
            Assert.AreEqual(UserName, Client.UserName);
            Assert.AreEqual(Password, Client.Password);
            Assert.AreEqual(ServerUri, Client.ServerUri);
            Assert.AreEqual(true, Client.EnableSsl);
        }

        [TestMethod]
        public void Instance_is_initialized_correctly_without_ssl()
        {
            const bool enableSsl = false;
            Client = new FtpClient();
            Client.Connect(UserName, Password, ServerUri, enableSsl);
            Assert.AreEqual(enableSsl, Client.EnableSsl);
        }

        [TestMethod]
        public void DirectoryListing_returns_results()
        {
            //WebRequest.RegisterPrefix("ftp://", )
            //var folders = Client.GetDirectoryListing();
            //Assert.IsNotNull(folders);
        }
    }
}
