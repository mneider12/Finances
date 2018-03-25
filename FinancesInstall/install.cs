using Finances.Model;
using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinancesInstall
{
    class Install
    {
        static void Main(string[] args)
        {
            IFileSystemManagerFactory fileSystemManagerFactory;
            IRecordIdMapFactory recordIdMapFactory;
            createFactories(out fileSystemManagerFactory, out recordIdMapFactory);

            IFileSystemManager fileSystemManager = createFileSystem(fileSystemManagerFactory);


            IRecordIdMap recordIdMap = recordIdMapFactory.create(fileSystemManager);
        }

        private static void createFactories(out IFileSystemManagerFactory fileSystemManagerFactory, out IRecordIdMapFactory recordIdMapFactory)
        {
            fileSystemManagerFactory = new FileSystemManagerFactory();
            recordIdMapFactory = new RecordIdMapFactory();
        }

        private static IFileSystemManager createFileSystem(IFileSystemManagerFactory fileSystemManagerFactory)
        {
            IFileSystemManager fileSystemManager = fileSystemManagerFactory.create();
            Directory.CreateDirectory(fileSystemManager.getDataDirectory());

            return fileSystemManager;
        }
    }
}
