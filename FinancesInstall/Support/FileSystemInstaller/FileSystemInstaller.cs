using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public static class FileSystemInstaller
    {
        public static void run(IDirectoryPathBuilder directoryPathBuilder)
        {
            foreach (LogicalDirectory logicalDirectory in Enum.GetValues(typeof(LogicalDirectory)))
            {
                string directoryPath = directoryPathBuilder.getPath(logicalDirectory);
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
