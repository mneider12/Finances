using System;
using System.Collections.Generic;

namespace Finances.Model
{
    public class MockRecordIdManager : IRecordIdManager
    {
        public int getNextId(RecordType type)
        {
            int nextId = nextRecordIds[type];
            nextRecordIds[type]++;
            return nextId;
        }

        public MockRecordIdManager()
        {
            load();
        }

        private Dictionary<RecordType, int> nextRecordIds;

        /// <summary>
        /// Initialize all types to 1 in nextRecordIds
        /// </summary>
        /// <returns>always true</returns>
        private bool load()
        {
            nextRecordIds = new Dictionary<RecordType, int>();
            foreach (RecordType type in Enum.GetValues(typeof(RecordType)))
            {
                nextRecordIds.Add(type, 1);
            }
            return true;
        }
    }
}