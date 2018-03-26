using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class FileSystemManager : IFileSystemManager
    {
        public FileSystemManager()
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

        private string dataDirectoryPath;

        private const string APP_DIRECTORY = "Finances";
        private const string DATA_DIRECTORY = "data";
        private const string RECORD_ID_MAP_FILE_NAME = "next_id.ser";
        private const string DATABASE_FILE_NAME = "database.db";

        private void setDataDirectory()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dataDirectoryPath = Path.Combine(appDataPath, APP_DIRECTORY, DATA_DIRECTORY);

            if (HttpContext.Current != null)
            {
                dataDirectoryPath = HttpContext.Current.Server.MapPath(dataDirectoryPath);
            }
        }
    }
}