using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.IO
{
    public interface IFileSystemInstaller
    {
        void create(IFileSystemManager fileSystemManager);
    }
}
