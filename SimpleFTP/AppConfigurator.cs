using Autofac;
using SimpleFTP.Core.FileSystem;
using SimpleFTP.Core.Ftp;

namespace SimpleFTP
{
    public sealed class AppConfigurator
    {
        public static AppConfigurator Instance = new AppConfigurator();

        private IContainer Container { get; set; }

        private AppConfigurator()
        {
            RegisterComponents();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        private void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FtpClient>().As<IFtpClient>();
            builder.RegisterType<FileSystemHelper>().As<IFileSystemHelper>();
            Container = builder.Build();
        }
    }
}
