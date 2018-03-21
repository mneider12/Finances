using System;
using System.Collections.Generic;

namespace Finances.Model.Shared.RecordIdManager
{
    public class MockRecordIdManager : IRecordIdManager
    {
        private Dictionary<RecordType, int> nextRecordIds;

        public int getNextId(RecordType type)
        {
            int nextId = nextRecordIds[type];
            nextRecordIds[type]++;
            return nextId;
         }

        /// <summary>
        /// Initialize all types to 1 in nextRecordIds
        /// </summary>
        /// <returns>always true</returns>
        public bool load()
        {
            nextRecordIds = new Dictionary<RecordType, int>();
            foreach (RecordType type in Enum.GetValues(typeof(RecordType)))
            {
                nextRecordIds.Add(type, 1);
            }
            return true;
        }

        /// <summary>
        /// Do nothing, this mock version is non-persistent
        /// </summary>
        /// <returns>always true</returns>
        public bool save()
        {
            return true;
        }
    }
}