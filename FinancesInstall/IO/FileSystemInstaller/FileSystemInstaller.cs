using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.IO
{
    public class FileSystemInstaller : IFileSystemInstaller
    {
        public void create(IFileSystemManager fileSystemManager)
        {
            Directory.CreateDirectory(fileSystemManager.getDataDirectoryPath());
        }
    }
}
