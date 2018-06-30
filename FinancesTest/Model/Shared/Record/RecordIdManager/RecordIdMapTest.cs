using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancesTest.Install;
using Finances.Model;
using FinancesTest.IO;

namespace FinancesTest.Model
{
    [TestClass]
    public class RecordIdMapTest
    {
        [TestMethod]
        public void getNextIdTest()
        {

        }

        [TestMethod]
        public void setGetLoadTest()
        {
            int nextId = 10;
            //RecordIdMap recordIdMap = new RecordIdMap(fileSystemManager);

            /*recordIdMap[RecordType.CashTransaction] = nextId;

            Assert.AreEqual(nextId, recordIdMap[RecordType.CashTransaction]);

            RecordIdMap recordIdMapLoaded = new RecordIdMap(fileSystemManager);

            Assert.AreEqual(nextId, recordIdMap[RecordType.CashTransaction]);*/
        }

        [TestInitialize]
        public void initialize()
        {
            //TestInstall.Main(null);
            //fileSystemManager = new TestFileSystemManager();
        }

        [TestCleanup]
        public void cleanup()
        {
            //fileSystemManager.cleanup();
        }
    }
}
