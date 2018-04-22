using Admin.Support;
using Finances.Import;
using Finances.IO;
using Finances.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Main
{
    /// <summary>
    /// class to house the admin console main method
    /// </summary>
    public static class Admin
    {
        /// <summary>
        /// run the administrator console
        /// right now it will load the file Import/cash_transactions_individual.txt into the database.
        /// </summary>
        public static void Main()
        {
            IMenu mainMenu = new MainMenu();
            mainMenu.run();
            /*IDirectoryPathBuilder directoryPathBuilder = new DirectoryPathBuilder("");
            IFilePathBuilder filePathBuilder = new FilePathBuilder(directoryPathBuilder);
            IFileSystemManager fileSystemManager = new FileSystemManager(filePathBuilder);
            IRecordIdManager recordIdManager = new RecordIdManager(fileSystemManager);
            ICashTransactionFactory cashTransactionFactory = new CashTransactionFactory(recordIdManager);
            ICashTransactionLoader cashTransactionLoader = new CashTransactionLoader(cashTransactionFactory, fileSystemManager);

            string importPath = Path.Combine("Import", "cash_transactions_individual.txt");
            cashTransactionLoader.load(importPath);*/
        }
    }
    
}
