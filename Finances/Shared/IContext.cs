using Finances.IO;
using Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Shared
{
    public interface IContext
    {
        IFileSystemManager FileSystemManager { get; }
        IDatabaseManager DatabaseManager { get; }
        IRecordIdManager RecordIdManager { get; }
    }
}
