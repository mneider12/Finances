using Finances.IO;
using FinancesInstall.Support;
using FinancesTest.IO;

namespace FinancesTest.Install
{
    public class TestInstall
    {
        public static void Main(string[] args)
        {
            IFileSystemManager fileSystemManager = new MockFileSystemManager();

            Installer installer = new Installer(fileSystemManager);
            installer.run();
        }
    }
}
