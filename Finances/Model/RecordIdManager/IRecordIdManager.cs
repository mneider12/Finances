using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Model.RecordIdManager
{
    public interface IRecordIdManager
    {
        int getNextId(RecordType type);
        bool load();
        bool save();
    }
}