using Finances.IO;
using FinancesInstall.Support;
using System;

namespace FinancesInstall.Main
{
    class Install
    {
        public static void Main(string[] args)
        {
            string rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Installer.run(rootDirectory);
        }
    }
}
