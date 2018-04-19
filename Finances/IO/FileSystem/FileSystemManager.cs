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
        /// Save an object to a local file
        /// </summary>
        /// <param name="data">object to save</param>
        /// <param name="file">file to save to</param>
        public void save(object data, LocalFile file)
        {
            using (FileStream fileStream = createFile(file))
            {
                XmlObjectSerializer serializer = new DataContractSerializer(data.GetType());
                serializer.WriteObject(fileStream, data);
            }
        }
        /// <summary>
        /// Load an object from a local file
        /// </summary>
        /// <param name="type">type of object to load</param>
        /// <param name="file">file to load from</param>
        /// <returns></returns>
        public object load(Type type, LocalFile file)
        {
            using (FileStream fileStream = openReadFile(file))
            {
                XmlObjectSerializer serializer = new DataContractSerializer(type);
                return serializer.ReadObject(fileStream);
            }
        }

        private const string APP_DIRECTORY = "Finances";
        private const string DATA_DIRECTORY = "data";
        private const string IMPORT_DIRECTORY = "import";
        /// <summary>
        /// Create a file
        /// </summary>
        /// <param name="file">file to create</param>
        /// <returns>file stream to write to the new file</returns>
        private FileStream createFile(LocalFile file)
        {
            string filePath = getFilePath(file);
            return File.Create(filePath);
        }
        /// <summary>
        /// Open a file for reading
        /// </summary>
        /// <param name="file">file to open</param>
        /// <returns>file stream to read from the file</returns>
        private FileStream openReadFile(LocalFile file)
        {
            string filePath = getFilePath(file);
            return File.OpenRead(filePath);
        }
        /// <summary>
        /// Get the path to a file
        /// </summary>
        /// <param name="file">local file</param>
        /// <returns>path to the file</returns>
        private string getFilePath(LocalFile file)
        {
            string directoryPath = getDirectoryPath(file.LogicalDirectory);
            return Path.Combine(directoryPath, file.FileName);
        }
        /// <summary>
        /// Get the path to a logical directory
        /// </summary>
        /// <param name="logicalDirectory">logical directory</param>
        /// <returns>path to the logical directory</returns>
        private string getDirectoryPath(LogicalDirectory logicalDirectory)
        {
            string appDirectoryPath = getAppDirectoryPath();
            string directoryRelativePath;
            switch (logicalDirectory)
            {
                case LogicalDirectory.Import:
                    directoryRelativePath = IMPORT_DIRECTORY;
                    break;
                case LogicalDirectory.Data:
                default:
                    directoryRelativePath = DATA_DIRECTORY;
                    break;
            }

            return Path.Combine(appDirectoryPath, directoryRelativePath);
        }
        /// <summary>
        /// Get the path to the application root directory
        /// </summary>
        /// <returns>path to the application root directory</returns>
        private string getAppDirectoryPath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appDataPath, APP_DIRECTORY);
        }
    }
}