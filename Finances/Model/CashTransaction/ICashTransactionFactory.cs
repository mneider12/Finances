using Finances.Model.RecordIdManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransactionFactory
    {
        ICashTransaction create(DateTime date, decimal amount);
    }
}
