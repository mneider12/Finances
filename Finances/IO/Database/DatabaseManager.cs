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
        /// <summary>
        /// Insert one row into a table
        /// </summary>
        /// <param name="tableName">name of the table to insert into</param>
        /// <param name="values">values to insert. Calls the toString method for each object</param>
        /// <returns>true on sucess, false on failure</returns>
        public bool insertOne(string tableName, params object[] values)
        {
            string insertSql = getInsertOneSql(tableName, values);
            int insertedRows = executeNonQuery(insertSql);
            return insertedRows == 1;
        }

        /// <summary>
        /// Select one record from a table
        /// </summary>
        /// <param name="tableName">name of table to select from</param>
        /// <param name="primaryKey">primary key</param>
        /// <returns>column values</returns>
        public NameValueCollection selectOne(string tableName, int primaryKey)
        {
            string selectSql = getSelectOneSql(tableName, primaryKey);
            return executeReader(selectSql)[0];
        }

        /// <summary>
        /// Delete one record from a table
        /// </summary>
        /// <param name="tableName">name of table to delete from</param>
        /// <param name="primaryKey">primary key</param>
        /// <returns>true on success, false on failure</returns>
        public bool deleteOne(string tableName, int primaryKey)
        {
            string deleteSql = getDeleteSql(tableName, primaryKey);
            int deletedRows = executeNonQuery(deleteSql);
            return deletedRows == 1;
        }

        /// <summary>
        /// Super lazy implementation just used by DatabaseInstaller for now. Should make a smarter one.
        /// </summary>
        /// <param name="createSql"></param>
        /// <returns></returns>
        public bool create(string createSql)
        {
            executeNonQuery(createSql);
            return true;
        }
        #endregion

        #region public constructors
        public DatabaseManager(string databaseFilePath)
        {
            this.databaseFilePath = databaseFilePath;
        }
        #endregion

        private string databaseFilePath;

        #region private methods
        private string getInsertOneSql(string tableName, params object[] values)
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

        private string getSelectOneSql(string tableName, int primaryKey)
        {
            return "SELECT * FROM " + tableName + " WHERE id=" + primaryKey;
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

        #region executeReader
        private List<NameValueCollection> executeReader(string selectSql)
        {
            using (SQLiteConnection databaseConnection = openDatabaseConnection())
            {
                return executeReader(selectSql, databaseConnection);
            }
        }

        private List<NameValueCollection> executeReader(string selectSql, SQLiteConnection databaseConnection)
        {
            using (SQLiteCommand command = new SQLiteCommand(selectSql, databaseConnection))
            {
                return executeReader(command);
            }
        }

        private static List<NameValueCollection> executeReader(SQLiteCommand command)
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                return executeReader(reader);
            }
        }

        private static List<NameValueCollection> executeReader(SQLiteDataReader reader)
        {
            List<NameValueCollection> results = new List<NameValueCollection>();
            while (reader.Read())
            {
                results.Add(reader.GetValues());
            }
            return results;
        }
        #endregion

        private SQLiteConnection openDatabaseConnection()
        {
            SQLiteConnection databaseConnection = new SQLiteConnection("Data Source=" + databaseFilePath);
            databaseConnection.Open();

            return databaseConnection;
        }
        #endregion
    }
}