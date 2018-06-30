using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.IO.FileSystem
{
    public class FileSystemManagerMock : IFileSystemManager
    {
        public object load(Type type, LocalFile file)
        {
            throw new NotImplementedException();
        }

        public void save(object data, LocalFile file)
        {
            throw new NotImplementedException();
        }
    }
}
