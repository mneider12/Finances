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
        public MockFileSystemManager()
        {
            setDataDirectory();
        }

        public string getDataDirectoryPath()
        {
            return dataDirectoryPath;
        }

        public string getRecordIdMapPath()
        {
            return Path.Combine(dataDirectoryPath, RECORD_ID_MAP_FILE_NAME);
        }

        public string getDatabasePath()
        {
            return Path.Combine(dataDirectoryPath, DATABASE_FILE_NAME);
        }

        private void setDataDirectory()
        {
            dataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATA_DIRECTORY);
        }

        private string dataDirectoryPath;

        private const string DATA_DIRECTORY = "data";
        private const string RECORD_ID_MAP_FILE_NAME = "next_id.ser";
        private const string DATABASE_FILE_NAME = "database.db";
    }
}
