using Finances.Model;
using Finances.IO;
using FinancesInstall.IO;
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
            
            createDatabase(fileSystemManager, databaseManager);

            IRecordIdMap recordIdMap = new RecordIdMap(fileSystemManager, true);
        }

        private static void createDatabase(IFileSystemManager fileSystemManager, IDatabaseManager databaseManager)
        {
            DatabaseInstaller databaseInstaller = new DatabaseInstaller(fileSystemManager, databaseManager);
            databaseInstaller.run();
        }
    }
}
