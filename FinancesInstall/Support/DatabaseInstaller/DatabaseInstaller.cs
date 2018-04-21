using Finances.IO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public static class DatabaseInstaller
    {
        public static IDatabaseManager run(string databaseFilePath)
        {
            SQLiteConnection.CreateFile(databaseFilePath);

            IDatabaseManager databaseManager = new DatabaseManager(databaseFilePath);
            createCashTranasactionsTable(databaseManager);

            return databaseManager;
        }

        private static void createCashTranasactionsTable(IDatabaseManager databaseManager)
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
