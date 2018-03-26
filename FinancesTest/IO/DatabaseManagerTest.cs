using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Finances.IO;
using FinancesTest.Install;
using System.Data.SQLite;
using System.Collections.Specialized;

namespace FinancesTest.IO
{
    [TestClass]
    public class DatabaseManagerTest
    {
        [TestMethod]
        public void insertSelectDeleteTest()
        {
            string tableName = "cash_transaction";
            int id = 1;
            long jan2000 = new DateTime(2000, 1, 1).Ticks;
            decimal amount = 500.55m;

            databaseManager.insert(tableName, id, jan2000, amount);

            NameValueCollection values = databaseManager.select(tableName, id)[0];
            Assert.AreEqual(id, int.Parse(values["id"]));
            Assert.AreEqual(jan2000, long.Parse(values["date"]));
            Assert.AreEqual(amount, decimal.Parse(values["amount"]));

            databaseManager.delete(tableName, id);
        }

        [TestMethod]
        public void getInsertSqlTest()
        {
            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('1');", databaseManagerPrivate.Invoke("getInsertSql", "TEST_TABLE", "1"));
            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('A','B');", databaseManagerPrivate.Invoke("getInsertSql", "TEST_TABLE", "A", "B"));
        }

        #region setup and teardown
        [TestInitialize]
        public void setup()
        {
            TestInstall.Main(null);
            fileSystemManager = new MockFileSystemManager();
            databaseManager = new DatabaseManager(fileSystemManager);
            databaseManagerPrivate = new PrivateObject(databaseManager);
        }
        #endregion

        #region private variables
        private IFileSystemManager fileSystemManager;
        private IDatabaseManager databaseManager;
        private PrivateObject databaseManagerPrivate;
        #endregion
    }
}
