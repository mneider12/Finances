using Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Import
{
    public interface ICashTransactionLoader
    {
        List<ICashTransaction> load(string relativeFilePath);
    }
}
