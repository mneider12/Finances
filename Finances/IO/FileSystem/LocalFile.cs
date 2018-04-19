using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class LocalFile : ILocalFile
    {
        public LogicalDirectory LogicalDirectory
        {
            get; private set;
        }

        public string FileName
        {
            get; private set;
        }

        public LocalFile(LogicalDirectory logicalDirectory, string fileName)
        {
            LogicalDirectory = logicalDirectory;
            FileName = fileName;
        }
    }
}