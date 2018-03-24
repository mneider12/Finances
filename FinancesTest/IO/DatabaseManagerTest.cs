using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Finances.IO;

namespace FinancesTest.IO
{
    [TestClass]
    public class DatabaseManagerTest
    {
        [TestMethod]
        public void insertTest()
        {
            string tableName = "cash_transaction";
            string id = "1";
            string date;
        }

        #region getInsertSqlTest
        [TestMethod]
        public void getInsertSqlTest()
        {
            getInsertSqlTableNameExceptionTest();
            getInsertSqlEmptyValuesExceptionTest();

            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('1')", databaseManagerPrivate.Invoke("getInsertSql", "TEST_TABLE", "1"));
            Assert.AreEqual("INSERT INTO TEST_TABLE VALUES ('A','B')", databaseManagerPrivate.Invoke("getInsertSql", "TEST_TABLE", "A", "B"));
        }
        
        private void getInsertSqlTableNameExceptionTest()
        {
            try
            {
                string tableName = null;
                databaseManagerPrivate.Invoke("getInsertSql", tableName);
            }
            catch (InvalidSqlException e)
            {
                Assert.AreEqual("table name is required for insert command", e.Message);
                return;
            }

            Assert.Fail();  //expected to hit the exception
        }   
    

        private void getInsertSqlEmptyValuesExceptionTest()
        {
            try
            { 
                string tableName = "TEST_TABLE";
                databaseManagerPrivate.Invoke("getInsertSql", tableName);
            }
            catch (InvalidSqlException e)
            {
                Assert.AreEqual("values required for insert command", e.Message);
                return;
            }

            Assert.Fail();
        }
        #endregion

        #region setup and teardown
        [TestInitialize]
        public void setup()
        {
            IFileSystemManagerFactory fileSystemManagerFactory = new MockFileSystemManagerFactory();
            fileSystemManager = fileSystemManagerFactory.create();

            if (Directory.Exists(fileSystemManager.getDataDirectory()))
            {
                Assert.Fail("test directory already exists");
            }
            else
            {
                Directory.CreateDirectory(fileSystemManager.getDataDirectory());
            }

            IDatabaseManagerFactory databaseManagerFactory = new DatabaseManagerFactory(fileSystemManager);
            databaseManager = databaseManagerFactory.create();
            databaseManagerPrivate = new PrivateObject(databaseManager);
        }

        [TestCleanup]
        public void teardown()
        {
            Directory.Delete(fileSystemManager.getDataDirectory(), true);
        }
        #endregion

        #region private members
        private IFileSystemManager fileSystemManager;
        private IDatabaseManager databaseManager;
        private PrivateObject databaseManagerPrivate;
        #endregion
    }
}
