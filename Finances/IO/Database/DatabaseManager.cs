using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;

namespace Finances.IO
{
    public class DatabaseManager : IDatabaseManager
    {

        #region public methods
        public bool insert(string tableName, params object[] values)
        {
            string insertSql = getInsertSql(tableName, values);
            int insertedRows = executeNonQuery(insertSql);
            return insertedRows == 1;
        }

        public List<NameValueCollection> select(string tableName, int primaryKey)
        {
            string selectSql = getSelectSql(tableName, primaryKey);

            List<NameValueCollection> results = new List<NameValueCollection>();
            using (SQLiteConnection databaseConnection = openDatabaseConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand(selectSql, databaseConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader.GetValues());
                        }
                    }
                }
            }
            return results;
        }

        public bool delete(string tableName, int primaryKey)
        {
            string deleteSql = getDeleteSql(tableName, primaryKey);
            int deletedRows = executeNonQuery(deleteSql);
            return deletedRows == 1;
        }
        #endregion

        #region public constructors
        public DatabaseManager(IFileSystemManager fileSystemManager)
        {
            setDatabasePath(fileSystemManager);
        }
        #endregion

        #region private methods
        private string getInsertSql(string tableName, params object[] values)
        {
            string insertSql = "INSERT INTO " + tableName +
                               " VALUES (";

            bool firstValue = true;
            foreach (object value in values)
            {
                if (firstValue)
                {
                    firstValue = false;
                }
                else
                {
                    insertSql = insertSql + ",";
                }

                insertSql = insertSql + "'" + value.ToString() + "'";
            }

            insertSql = insertSql + ");";
            return insertSql;
        }

        private string getSelectSql(string tableName, int primaryKey)
        {
            return "SELECT * FROM " + tableName + " WHERE ID=" + primaryKey;
        }

        private string getDeleteSql(string tableName, int primaryKey)
        {
            return "DELETE FROM " + tableName + " WHERE ID=" + primaryKey + ";";
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