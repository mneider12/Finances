using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Finances.IO
{
    /// <summary>
    /// manage interacting with the file system for storing persistent data
    /// </summary>
    public class FileSystemManager : IFileSystemManager
    {
        /// <summary>
        /// Create the file system manager.
        /// Caches the data directory
        /// </summary>
        public FileSystemManager()
        {
            setDataDirectory();
        }
        /// <summary>
        /// Get the absolute file path for a logical directory
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <param name="logicalDirectory">logical directory</param>
        /// <returns>absolute file path</returns>
        public string getDataFilePath(string fileName, LogicalDirectory logicalDirectory)
        {
            switch (logicalDirectory)
            {
                case LogicalDirectory.Import:
                    return Path.Combine(getDataDirectoryPath(), IMPORT_DIRECTORY);
                case LogicalDirectory.Home:
                default:
                    return getDataDirectoryPath();
            }
        }

        private string getDataDirectoryPath()
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

        public FileStream openFile(string relativeFilePath)
        {
            string fullFilePath = Path.Combine(dataDirectoryPath, relativeFilePath);
            return File.OpenRead(fullFilePath);
        }

        private string dataDirectoryPath;

        private const string APP_DIRECTORY = "Finances";
        private const string DATA_DIRECTORY = "data";
        private const string IMPORT_DIRECTORY = "import";
        private const string RECORD_ID_MAP_FILE_NAME = "next_id.ser";
        private const string DATABASE_FILE_NAME = "database.sqlite";

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