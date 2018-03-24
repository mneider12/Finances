using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO.FileSystem
{
    public class FileSystemManagerFactory : IFileSystemManagerFactory
    {
        public IFileSystemManager create()
        {
            return new FileSystemManager();
        }
    }
}