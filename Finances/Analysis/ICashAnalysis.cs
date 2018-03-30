using Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Analysis
{
    public interface ICashAnalysis
    {
        double getRateOfReturn(List<ICashTransaction> cashTransactions, double presentValue);
    }
}
