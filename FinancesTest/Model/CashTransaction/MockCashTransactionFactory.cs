using Finances.Model.CashTransaction;
using Finances.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.Model.CashTransaction
{
    class MockCashTransactionFactory : ICashTransactionFactory
    {
        public ICashTransaction create(DateTime date, decimal amount)
        {
            return new Finances.Model.CashTransaction.CashTransaction(recordIdManager, date, amount);
        }

        public MockCashTransactionFactory()
        {
            recordIdManager = new MockRecordIdManager();
        }

        private IRecordIdManager recordIdManager;
    }
}
