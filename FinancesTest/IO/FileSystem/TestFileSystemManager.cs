using Finances.IO;
using System;
using System.IO;

namespace FinancesTest.IO
{
    public class TestFileSystemManager : IFileSystemManager
    {
        public void cleanup()
        {
            Directory.Delete(dataDirectoryPath, true);
        }

        public TestFileSystemManager()
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
        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}
