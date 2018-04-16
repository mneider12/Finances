using Finances.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Finances.Model
{
    public class RecordIdManager : IRecordIdManager
    {
        public int getNextId(RecordType type)
        {
            int nextId = nextIdMap[type];
            nextIdMap[type]++;
            return nextId;
        }

        public RecordIdManager(IFileSystemManager fileSystemManager)
        {
            setNextIdMapPath(fileSystemManager);
            loadNextIdMap(fileSystemManager);
        }

        private Dictionary<RecordType, int> nextIdMap;
        private string nextIdMapPath;

        private const string nextIdMapFileName = "next_id.ser";

        private void setNextIdMapPath(IFileSystemManager fileSystemManager)
        {
            nextIdMapPath = fileSystemManager.getRecordIdMapPath();
        }

        private void loadNextIdMap(IFileSystemManager fileSystemManager)
        {
            //fileSystemManager.des
            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<RecordType, int>));
            using (StreamReader streamReader = new StreamReader(nextIdMapPath))
            {
                nextIdMap = (Dictionary<RecordType, int>) serializer.Deserialize(streamReader);
            }
        }
    }
}