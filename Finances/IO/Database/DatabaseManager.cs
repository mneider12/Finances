using System;
using System.Data.SQLite;
using System.IO;

namespace Finances.IO
{
    public class DatabaseManager : IDatabaseManager
    {
        

        public bool insert(string tableName, params string[] values)
        {
            string insertSql = getInsertSql(tableName, values);
            int insertedRows = executeNonQuery(insertSql);
            return insertedRows == 1;
        }

        public DatabaseManager(IFileSystemManager fileSystemManager)
        {
            setDatabasePath(fileSystemManager);
        }

        private string getInsertSql(string tableName, params string[] values)
        {
            string insertSql = "INSERT INTO " + tableName +
                               " VALUES (";

            bool firstValue = true;
            foreach (string value in values)
            {
                if (firstValue)
                {
                    firstValue = false;
                }
                else
                {
                    insertSql = insertSql + ",";
                }

                insertSql = insertSql + "'" + value + "'";
            }
            return "";
        }

        private int executeNonQuery(string sql)
        {
            using (SQLiteConnection databaseConnection = openDatabaseConnection())
            {
                return executeNonQuery(sql, databaseConnection);
            }
        }

        private int executeNonQuery(string sql, SQLiteConnection databaseConnection)
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, databaseConnection))
            {
                return command.ExecuteNonQuery();
            }
        }

        private SQLiteConnection openDatabaseConnection()
        {
            SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=" + databasePath);
            databaseConnection.Open();

            return databaseConnection;
        }

        private void setDatabasePath(IFileSystemManager fileSystemManager)
        {
            databasePath = Path.Combine(fileSystemManager.getDataDirectory(), DATABASE_FILE_NAME);
        }

        private string databasePath;

        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}