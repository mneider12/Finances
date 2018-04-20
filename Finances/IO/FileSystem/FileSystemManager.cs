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
    public class FileSystemManager : FilePathBuilder, IFileSystemManager
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
        /// <summary>
        /// Create a file system manager
        /// </summary>
        /// <param name="rootDirectory">root directory to store app data in
        ///                             this will be something like the general local Application data directory/</param>
        public FileSystemManager(string rootDirectory) : base(rootDirectory) { }

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
    }
}