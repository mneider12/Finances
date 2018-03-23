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
            string directoryPath = Path.Combine(HOME_DIRECTORY, DATA_DIRECTORY);
            return HttpContext.Current.Server.MapPath(directoryPath);
        }

        private const string HOME_DIRECTORY = "~";
        private const string DATA_DIRECTORY = "data";
    }
}