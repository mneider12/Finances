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
        string getDataDirectoryPath();
        string getRecordIdMapPath();
        string getDatabasePath();

        void serialize(object graph, string path, XmlObjectSerializer serializer);
        FileStream openFile(string relativePath);
    }
}
