using Finances.IO;
using System;
using System.IO;
using System.Runtime.Serialization;

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

        public void serialize(object graph, string path, XmlObjectSerializer serializer)
        {
            using (FileStream fileStream = File.Create(path))
            {
                serializer.WriteObject(fileStream, graph);
            }
        }

        private void setDataDirectory()
        {
            dataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATA_DIRECTORY);
        }

        public FileStream openFile(string relativePath)
        {
            throw new NotImplementedException();
        }

        private string dataDirectoryPath;

        private const string DATA_DIRECTORY = "data";
        private const string RECORD_ID_MAP_FILE_NAME = "next_id.ser";
        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}
