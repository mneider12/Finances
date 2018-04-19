using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Finances.IO
{
    public interface IFileSystemManager
    {
        string getFilePath(string fileName, LogicalDirectory logicalDirectory);
        void save(object data, string filePath);
    }
}
