using Finances.Model.RecordIdManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Model.CashTransaction
{
    public class CashTransactionFactory : ICashTransactionFactory
    {
        public ICashTransaction create(DateTime date, decimal amount)
        {
            return new CashTransaction(recordIdManager, date, amount);
        }

        public CashTransactionFactory(IRecordIdManager recordIdManager)
        {
            this.recordIdManager = recordIdManager;
        }

        private IRecordIdManager recordIdManager;
    }
}
