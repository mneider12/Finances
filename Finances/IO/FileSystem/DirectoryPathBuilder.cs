using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class DirectoryPathBuilder : IDirectoryPathBuilder
    {
        /// <summary>
        /// Get the path to a logical directory
        /// </summary>
        /// <param name="logicalDirectory">logical directory</param>
        /// <returns>path to the logical directory</returns>
        public string getPath(LogicalDirectory logicalDirectory)
        {
            string appDirectoryPath = getAppDirectoryPath();
            string relativePath = getRelativePath(logicalDirectory);

            return Path.Combine(appDirectoryPath, relativePath);
        }

        public DirectoryPathBuilder(string rootDirectory)
        {
            this.rootDirectory = rootDirectory;
        }

        private string rootDirectory;

        private const string APP_DIRECTORY = "Finances";
        private const string DATA_DIRECTORY = "data";
        private const string IMPORT_DIRECTORY = "import";

        /// <summary>
        /// Get the path to the application root directory
        /// </summary>
        /// <returns>path to the application root directory</returns>
        private string getAppDirectoryPath()
        {
            return Path.Combine(rootDirectory, APP_DIRECTORY);
        }

        /// <summary>
        /// Get the relative path from the app directory for a logical directory
        /// </summary>
        /// <param name="logicalDirectory"></param>
        /// <returns>relative path from the app directory</returns>
        private string getRelativePath(LogicalDirectory logicalDirectory)
        {
            string relativePath;
            switch (logicalDirectory)
            {
                case LogicalDirectory.Import:
                    relativePath = IMPORT_DIRECTORY;
                    break;
                case LogicalDirectory.Data:
                    relativePath = DATA_DIRECTORY;
                    break;
                default:
                    relativePath = "";
                    break;
            }
            return relativePath;
        }
    }
}