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
        void save(object data, LocalFile file);
        object load(Type type, LocalFile file);
    }
}
