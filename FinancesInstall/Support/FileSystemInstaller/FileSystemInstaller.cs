using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public class FileSystemInstaller : IFileSystemInstaller
    {
        public FileSystemInstaller(IFileSystemManager fileSystemManager)
        {
            this.fileSystemManager = fileSystemManager;
        }

        public void run()
        {
            Directory.CreateDirectory(fileSystemManager.getDataDirectoryPath());
        }

        private IFileSystemManager fileSystemManager;
    }
}
