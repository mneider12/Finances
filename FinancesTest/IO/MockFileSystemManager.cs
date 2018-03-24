using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.IO
{
    public class MockFileSystemManager : IFileSystemManager
    {
        public string getDataDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,DATA_DIRECTORY);
        }

        private const string DATA_DIRECTORY = "testData";
    }
}
