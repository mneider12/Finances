using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.IO
{
    public class SpecialFilePathBuilder : FilePathBuilder, ISpecialFilePathBuilder
    {
        public string getPath(SpecialFile file)
        {
            ILocalFile localFile;
            switch (file)
            {
                case SpecialFile.DATABASE:
                    localFile = new LocalFile(LogicalDirectory.Data, DATABASE_FILE_NAME);
                    break;
                default:
                    return "";
            }

            return getPath(localFile);
        }

        public SpecialFilePathBuilder(IDirectoryPathBuilder directoryPathBuilder) : base(directoryPathBuilder) { }

        private const string DATABASE_FILE_NAME = "database.sqlite";
    }
}
