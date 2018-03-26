using Finances.IO;
using Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public class Installer : IInstaller
    {
        public Installer(IFileSystemManager fileSystemManager)
        {
            this.fileSystemManager = fileSystemManager;
        }

        public void run()
        {
            createFileSystem();
            createDatabase();

            IRecordIdMap recordIdMap = new RecordIdMap(fileSystemManager, true);
        }

        private void createFileSystem()
        {
            FileSystemInstaller filesystemInstaller = new FileSystemInstaller(fileSystemManager);
            filesystemInstaller.run();
        }

        private void createDatabase()
        {
            DatabaseManager databaseManager = new DatabaseManager(fileSystemManager);
            DatabaseInstaller databaseInstaller = new DatabaseInstaller(fileSystemManager, databaseManager);
            databaseInstaller.run();
        }

        private IFileSystemManager fileSystemManager;
    }
}
