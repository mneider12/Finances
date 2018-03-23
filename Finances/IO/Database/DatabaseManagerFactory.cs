using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class DatabaseManagerFactory : IDatabaseManagerFactory
    {
        public IDatabaseManager create()
        {
            return new DatabaseManager(fileSystemManager);
        }

        public DatabaseManagerFactory(IFileSystemManager fileSystemManager)
        {
            this.fileSystemManager = fileSystemManager;
        }

        private IFileSystemManager fileSystemManager;
    }
}