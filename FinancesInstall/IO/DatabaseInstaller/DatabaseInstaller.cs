using Finances.IO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.IO
{
    public class DatabaseInstaller : IDatabaseInstaller
    {
        public DatabaseInstaller(IFileSystemManager fileSystemManager, IDatabaseManager databaseManager)
        {
            this.fileSystemManager = fileSystemManager;
            this.databaseManager = databaseManager;
        }

        public void run()
        {
            SQLiteConnection.CreateFile(fileSystemManager.getDatabasePath());
        }

        private IFileSystemManager fileSystemManager;
        private IDatabaseManager databaseManager;

        private void createCashTranasactionsTable()
        {
            string createSql = "CREATE TABLE `cash_transaction` ( " +
                                                                "`id`	INTEGER NOT NULL," +
                                                                "`date`	INTEGER," +
                                                                "`amount`	NUMERIC," +
                                                                "PRIMARY KEY(`id`)" +
                                                                ");";

            databaseManager.create(createSql);
        }
    }
}
