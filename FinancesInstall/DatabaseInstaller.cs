using Finances.IO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall
{
    public class DatabaseInstaller : DatabaseManager
    {
        public DatabaseInstaller(IFileSystemManager fileSystemManager) : base(fileSystemManager) { }

        public void run()
        {
            SQLiteConnection.CreateFile(databasePath);


        }

        private void createCashTranasactionsTable()
        {
            string createSql = "CREATE TABLE `cash_transaction` ( " +
                                                                "`id`	INTEGER NOT NULL," +
                                                                "`date`	INTEGER," +
                                                                "`amount`	NUMERIC," +
                                                                "PRIMARY KEY(`id`)" +
                                                                ");";

            executeNonQuery(createSql);

        }
    }
}
