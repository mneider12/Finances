using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Finances.Model
{
    public class RecordIdMap : IRecordIdMap
    {
        public int getNextId(RecordType type)
        {
            return nextIdMap[type];
        }

        public void setNextId(RecordType type, int nextId)
        {
            nextIdMap[type] = nextId;
        }

        public RecordIdMap(IFileSystemManager fileSystemManager) : this(fileSystemManager, false)
        {

        }

        public RecordIdMap(IFileSystemManager fileSystemManager, bool isNew)
        {
            this.fileSystemManager = fileSystemManager;
            nextIdMapPath = Path.Combine(fileSystemManager.getDataDirectory(), nextIdMapFileName);
            serializer = new XmlSerializer(typeof(Dictionary<RecordType, int>));

            if (isNew)
            {
                load();
            }
            else
            {
                nextIdMap = new Dictionary<RecordType, int>();
            }
        }

        private void load()
        {
            using (StreamReader streamReader = new StreamReader(nextIdMapPath))
            {
                nextIdMap = (Dictionary<RecordType, int>)serializer.Deserialize(streamReader);
            }
        }

        private void save()
        {
            using (FileStream fileStream = File.Create(nextIdMapPath))
            {
                serializer.Serialize(fileStream, nextIdMap);
            }
        }

        private Dictionary<RecordType, int> nextIdMap;
        private string nextIdMapPath;
        private IFileSystemManager fileSystemManager;
        private XmlSerializer serializer;

        private const string nextIdMapFileName = "next_id.ser";
    }
}