using Finances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.Model.CashTransaction
{
    public class MockCashTransactionFactory : CashTransactionFactory
    {
        public MockCashTransactionFactory() : base(new MockRecordIdManager())
        {

        }
    }
}
