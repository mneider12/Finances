using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finances.IO;
using Finances.Model;

namespace Finances.Shared
{
    public class Context : IContext
    {
        public IFileSystemManager FileSystemManager
        {
            get; private set;
        }

        public IDatabaseManager DatabaseManager
        {
            get; private set;
        }

        public IRecordIdManager RecordIdManager
        {
            get; private set;
        }

        public Context(string rootDirectory)
        {
            IDirectoryPathBuilder directoryPathBuilder = new DirectoryPathBuilder(rootDirectory);
            ISpecialFilePathBuilder filePathBuilder = new SpecialFilePathBuilder(directoryPathBuilder);

            FileSystemManager = new FileSystemManager(filePathBuilder);

            string databaseFilePath = filePathBuilder.getPath(SpecialFile.DATABASE);
            DatabaseManager = new DatabaseManager(databaseFilePath);

            RecordIdManager = new RecordIdManager(FileSystemManager);
        }
    }
}