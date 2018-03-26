using Finances.IO;
using FinancesInstall.Support;

namespace FinancesInstall.Main
{
    class Install
    {
        public static void Main(string[] args)
        {
            IFileSystemManager fileSystemManager = new FileSystemManager();

            IInstaller installer = new Installer(fileSystemManager);
            installer.run();
        }
    }
}
