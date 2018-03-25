using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class FileSystemManagerFactory : IFileSystemManagerFactory
    {
        public IFileSystemManager create()
        {
            return new FileSystemManager();
        }
    }
}