using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class FilePathBuilder : IFilePathBuilder
    {
        public string getPath(ILocalFile file)
        {
            string directoryPath = directoryPathBuilder.getPath(file.LogicalDirectory);
            return Path.Combine(directoryPath, file.FileName);
        }

        public FilePathBuilder(IDirectoryPathBuilder directoryPathBuilder)
        {
            this.directoryPathBuilder = directoryPathBuilder;
        }

        protected IDirectoryPathBuilder directoryPathBuilder;
    }
}