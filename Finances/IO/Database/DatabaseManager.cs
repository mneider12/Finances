using System;
using System.Data.SQLite;
using System.IO;

namespace Finances.IO
{
    public class DatabaseManager : IDatabaseManager
    {

        #region public methods
        public bool insert(string tableName, params string[] values)
        {
            string insertSql = getInsertSql(tableName, values);
            int insertedRows = executeNonQuery(insertSql);
            return insertedRows == 1;
        }
        #endregion

        #region public constructors
        public DatabaseManager(IFileSystemManager fileSystemManager)
        {
            setDatabasePath(fileSystemManager);
        }
        #endregion

        #region private methods
        private string getInsertSql(string tableName, params string[] values)
        {
            string message;
            if (!validateInsertParameters(out message, tableName, values))
            {
                throw new InvalidSqlException(message);
            }

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

            insertSql = insertSql + ")";
            return insertSql;
        }

        private bool validateInsertParameters(out string message, string tableName, params string[] values)
        {
            message = "";

            if (string.IsNullOrWhiteSpace(tableName))
            {
                message = "table name is required for insert command";
            }
            else if (values.Length == 0)
            {
                message = "values required for insert command";
            }

            return message.Equals("");
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
        #endregion

        #region private members
        private string databasePath;

        private const string DATABASE_FILE_NAME = "database.sqlite";
        #endregion
    }
}