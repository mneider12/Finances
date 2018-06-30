using Finances.IO;
using Finances.Model;
using Finances.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public static class Installer
    {
        public static IContext run(string rootDirectory)
        {

            IPathBuilder pathBuilder = getPathBuilder(rootDirectory);
           
            FileSystemInstaller.run(pathBuilder);
            IFileSystemManager fileSystemManager = new FileSystemManager(pathBuilder);

            string databaseFilePath = pathBuilder.getPath(SpecialFile.DATABASE);
            IDatabaseManager databaseManager = DatabaseInstaller.run(databaseFilePath);

            IRecordIdMap recordIdMap = new RecordIdMap(fileSystemManager, true);

            IContext context = new Context(rootDirectory);
            return context;
        }

        private static IPathBuilder getPathBuilder(string rootDirectory)
        {
            IDirectoryPathBuilder directoryPathBuilder = new DirectoryPathBuilder(rootDirectory);
            return new PathBuilder(directoryPathBuilder);
        }
    }
}
