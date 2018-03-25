using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finances.IO;

namespace Finances.Model
{
    public class RecordIdMapFactory : IRecordIdMapFactory
    {
        public IRecordIdMap create(IFileSystemManager fileSystemManager)
        {
            return new RecordIdMap(fileSystemManager, true);
        }

        public IRecordIdMap load(IFileSystemManager fileSystemManager)
        {
            return new RecordIdMap(fileSystemManager);
        }
    }
}