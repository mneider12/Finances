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
        public int this[RecordType type]
        {
            get
            {
                return nextIdMap[type];
            }
            set
            {
                nextIdMap[type] = value;
                fileSystemManager.serialize(nextIdMap, nextIdMapPath, serializer);
            }
        }

        public RecordIdMap(IFileSystemManager fileSystemManager) : this(fileSystemManager, false)
        {

        }

        public RecordIdMap(IFileSystemManager fileSystemManager, bool isNew)
        {
            this.fileSystemManager = fileSystemManager;
            nextIdMapPath = fileSystemManager.getRecordIdMapPath();
            serializer = new DataContractSerializer(typeof(Dictionary<RecordType, int>));

            if (isNew)
            {
                nextIdMap = new Dictionary<RecordType, int>();
                fileSystemManager.serialize(nextIdMap, nextIdMapPath, serializer);
            }
            else
            {
                load();   
            }
        }

        private void load()
        {
            using (FileStream fileStream = new FileStream(nextIdMapPath, FileMode.Open))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()))
                {
                    nextIdMap = (Dictionary<RecordType, int>)serializer.ReadObject(reader);
                }
            }
        }

        private Dictionary<RecordType, int> nextIdMap;
        private string nextIdMapPath;
        private IFileSystemManager fileSystemManager;
        private DataContractSerializer serializer;

        private const string nextIdMapFileName = "next_id.ser";
    }
}