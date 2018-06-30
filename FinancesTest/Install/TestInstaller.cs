using Finances.IO;
using Finances.Shared;
using FinancesInstall.Support;
using FinancesTest.IO;
using System;
using System.IO;

namespace FinancesTest.Install
{
    public class TestInstaller
    {
        public static IContext run()
        {
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Installer.run(rootDirectory);
        }

        public static void deinstall()
        {
            string appDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Finances");
            Directory.Delete(appDirectory);
        }
    }
}
