using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.IO
{
    public class MockFileSystemManagerFactory : IFileSystemManagerFactory
    {
        public IFileSystemManager create()
        {
            return new MockFileSystemManager();
        }
    }
}
