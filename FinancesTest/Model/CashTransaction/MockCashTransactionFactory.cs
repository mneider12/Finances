using Finances.Model;
using System;

namespace FinancesTest.Model
{
    class MockCashTransactionFactory : ICashTransactionFactory
    {
        public ICashTransaction create(DateTime date, decimal amount)
        {
            return new CashTransaction(recordIdManager, date, amount);
        }

        public MockCashTransactionFactory()
        {
            recordIdManager = new MockRecordIdManager();
        }

        private IRecordIdManager recordIdManager;
    }
}
