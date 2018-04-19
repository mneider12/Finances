using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finances.IO;
using System.IO;
using System.Collections.Generic;

namespace FinancesTest.IO.FileSystem
{
    [TestClass]
    public class FileSystemMangerTest
    {
        [TestMethod]
        public void saveTest()
        {
            Dictionary<string, int> wordLengthIndex = createWordLengthIndex();
            LocalFile file = new LocalFile(LogicalDirectory.Data, "wordLengthIndex.txt");
            fileSystemManager.save(wordLengthIndex, file);

            Dictionary<string, int> loadedWordLengthIndex = (Dictionary<string, int>) fileSystemManager.load(typeof(Dictionary<string, int>), file);
            Assert.AreEqual(4, loadedWordLengthIndex["test"]);
            Assert.AreEqual(5, loadedWordLengthIndex["piano"]);
            Assert.AreEqual(1, loadedWordLengthIndex["I"]);
        }
        private Dictionary<string, int> createWordLengthIndex()
        {
            Dictionary<string, int> wordLengthIndex = new Dictionary<string, int>();

            wordLengthIndex.Add("test", 4);
            wordLengthIndex.Add("piano", 5);
            wordLengthIndex.Add("I", 1);

            return wordLengthIndex;
        }

        [TestInitialize]
        public void initialize()
        {
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string appDirectory = Path.Combine(rootDirectory, "Finances");
            string dataDirectory = Path.Combine(appDirectory, "data");

            Directory.CreateDirectory(dataDirectory);

            fileSystemManager = new FileSystemManager(rootDirectory);
        }

        IFileSystemManager fileSystemManager;
    }
}
