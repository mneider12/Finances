using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.IO;

namespace FinancesInstall.Support
{
    public class PathBuilder : SpecialFilePathBuilder, IPathBuilder
    {
        public string getPath(LogicalDirectory logicalDirectory)
        {
            return directoryPathBuilder.getPath(logicalDirectory);
        }

        public PathBuilder(IDirectoryPathBuilder directoryPathBuilder) : base(directoryPathBuilder) { }
    }
}
