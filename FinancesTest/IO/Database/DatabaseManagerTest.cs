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
        public void insertSelectDeleteOneTest()
        {
            string tableName = "cash_transaction";
            int id = 1;
            long jan2000 = new DateTime(2000, 1, 1).Ticks;
            decimal amount = 500.55m;

            databaseManager.insertOne(tableName, id, jan2000, amount);

            NameValueCollection values = databaseManager.selectOne(tableName, id);
            Assert.AreEqual(id, int.Parse(values["id"]));
            Assert.AreEqual(jan2000, long.Parse(values["date"]));
            Assert.AreEqual(amount, decimal.Parse(values["amount"]));

            databaseManager.deleteOne(tableName, id);
        }

        [TestMethod]
        public void getInsertSqlTest()
        {
            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('1');", databaseManagerPrivate.Invoke("getInsertOneSql", "TEST_TABLE", "1"));
            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('A','B');", databaseManagerPrivate.Invoke("getInsertOneSql", "TEST_TABLE", "A", "B"));
        }

        [TestMethod]
        public void getSelectOneSqlTest()
        {
            Assert.AreEqual("SELECT * FROM TEST_TABLE WHERE id=1", databaseManagerPrivate.Invoke("getSelectOneSql", "TEST_TABLE", 1));
        }

        #region setup and teardown
        [TestInitialize]
        public void initialize()
        {
            TestInstall.Main(null);
            fileSystemManager = new TestFileSystemManager();
            databaseManager = new DatabaseManager("");
            databaseManagerPrivate = new PrivateObject(databaseManager);
        }

        [TestCleanup]
        public void cleanup()
        {
            fileSystemManager.cleanup();
        }
        #endregion

        #region private variables
        private TestFileSystemManager fileSystemManager;
        private IDatabaseManager databaseManager;
        private PrivateObject databaseManagerPrivate;
        #endregion
    }
}
