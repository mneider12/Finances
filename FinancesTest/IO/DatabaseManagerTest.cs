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
        public void getInsertSqlTest()
        {
            
        }

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
        }

        [TestCleanup]
        public void cleanup()
        {
            Directory.Delete(fileSystemManager.getDataDirectory(), true);
        }

        private IFileSystemManager fileSystemManager;

        #region boilerplate TestContext
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion
    }
}
