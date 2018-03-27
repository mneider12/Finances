using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Model
{
    public interface IRecordIdMap
    {
        int this[RecordType type] { get; set; }
    }
}