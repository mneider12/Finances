using Finances.Model;
using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace FinancesInstall
{
    class Install
    {
        static void Main(string[] args)
        {
            IFileSystemManager fileSystemManager = new FileSystemManager();
            IDatabaseManager databaseManager = new DatabaseManager(fileSystemManager);
            
            createFileSystem(fileSystemManager);
            createDatabase(fileSystemManager);

            IRecordIdMap recordIdMap = new RecordIdMap(fileSystemManager, true);
        }

        private static void createFileSystem(IFileSystemManager fileSystemManager)
        {
            Directory.CreateDirectory(fileSystemManager.getDataDirectory());
        }

        private static void createDatabase(IFileSystemManager fileSystemManager)
        {
            DatabaseInstaller databaseInstaller = new DatabaseInstaller(fileSystemManager);
            databaseInstaller.run();
        }
    }
}
