using Finances.IO;
using Finances.Model;
using FinancesTest.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstallTest.IO
{
    public class TestInstall
    {
        static void Main(string[] args)
        {
            IFileSystemManager fileSystemManager = new MockFileSystemManager();
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
