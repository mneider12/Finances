using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finances.IO;
using System.IO;

namespace FinancesTest.IO.FileSystem
{
    [TestClass]
    public class FileSystemMangerTest
    {
        [TestMethod]
        public void getAppDirectoryPathTest()
        {
            string expectedAppDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Finances");
            string actualAppDirectoryPath = (string) fileSystemManagerPrivate.Invoke("getAppDirectoryPath");

            Assert.AreEqual(expectedAppDirectoryPath, actualAppDirectoryPath);
        }

        [TestInitialize]
        public void initialize()
        {
            IFileSystemManager fileSystemManager = new FileSystemManager(AppDomain.CurrentDomain.BaseDirectory);
            fileSystemManagerPrivate = new PrivateObject(fileSystemManager);
        }

        private PrivateObject fileSystemManagerPrivate;
    }
}
