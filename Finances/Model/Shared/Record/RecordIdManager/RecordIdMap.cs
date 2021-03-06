﻿using Finances.IO;
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
    /// <summary>
    /// Implementation of a record ID map to keep track of record types and next available ID
    /// </summary>
    public class RecordIdMap : IRecordIdMap
    {
        /// <summary>
        /// Get the next available ID for a given RecordType
        /// </summary>
        /// <param name="type">type of record to get an ID for</param>
        /// <returns>Next available ID</returns>
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
            //nextIdMapFilePath = fileSystemManager.getFilePath(nextIdMapFileName, LogicalDirectory.Data);

            if (isNew)
            {
                nextIdMap = new Dictionary<RecordType, int>();
                //fileSystemManager.save(nextIdMap, nextIdMapFilePath);
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