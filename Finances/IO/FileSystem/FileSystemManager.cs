using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class FileSystemManager : IFileSystemManager
    {
        public string getDataDirectory()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string directoryPath = Path.Combine(appDataPath, APP_DIRECTORY, DATA_DIRECTORY);

            if (HttpContext.Current == null)
            {
                return directoryPath;
            }
            else
            {
                return HttpContext.Current.Server.MapPath(directoryPath);
            }
        }

        private const string APP_DIRECTORY = "Finances";
        private const string DATA_DIRECTORY = "data";
    }
}