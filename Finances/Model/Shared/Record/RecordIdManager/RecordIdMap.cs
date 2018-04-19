using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Finances.Model
{
    public class RecordIdMap : IRecordIdMap
    {
        public int getNextId(RecordType type)
        {
            int nextId = nextIdMap[type];
            nextIdMap[type]++;
            save();
            return nextId;
        }

        public RecordIdMap(string filePath)
        {

        }

        public RecordIdMap(IFileSystemManager fileSystemManager) : this(fileSystemManager, false)
        {

        }

        public RecordIdMap(IFileSystemManager fileSystemManager, bool isNew)
        {
            this.fileSystemManager = fileSystemManager;
            nextIdMapFilePath = fileSystemManager.getFilePath(nextIdMapFileName, LogicalDirectory.Home);

            if (isNew)
            {
                nextIdMap = new Dictionary<RecordType, int>();
                fileSystemManager.save(nextIdMap, nextIdMapFilePath);
            }
            else
            {
                load();   
            }
        }

        private void save()
        {

        }

        private void load()
        {
            using (FileStream fileStream = new FileStream(nextIdMapFilePath, FileMode.Open))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                {
                    nextIdMap = (Dictionary<RecordType, int>)serializer.ReadObject(reader);
                }
            }
        }

        private Dictionary<RecordType, int> nextIdMap;
        private string filePath;
        private IFileSystemManager fileSystemManager;
        private DataContractSerializer serializer;

        private string nextIdMapFilePath;
        private const string nextIdMapFileName = "next_id.ser";
    }
}