using Finances.Model.Shared;
using System;

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
