using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finances.Model;
using FinancesTest.Model.CashTransaction;
using System.Collections.Generic;
using Finances.Analysis;

namespace FinancesTest.Analysis
{
    [TestClass]
    public class CashAnalysisTest
    {
        /*[TestMethod]
        public void getRateOfReturnTestSimple()
        {
            IRecordIdManager recordIdManager = new MockRecordIdManager();
            ICashTransactionFactory cashTransactionFactory = new CashTransactionFactory(recordIdManager);

        }*/

        [TestMethod]
        public void getPresentValueTest()
        {
            List<ICashTransaction> cashTransactions = new List<ICashTransaction>();

            ICashTransactionFactory cashTransactionFactory = new MockCashTransactionFactory();

            DateTime date = DateTime.Today.Subtract(new TimeSpan(365, 6, 0, 0, 0)); // exactly one year ago (year = 365.25 days)
            decimal amount = 500m;
            cashTransactions.Add(cashTransactionFactory.create(date, amount));

            ICashAnalysis cashAnalysis = new CashAnalysis();
            PrivateObject privateCashAnalysis = new PrivateObject(cashAnalysis);

            Assert.AreEqual(750d, privateCashAnalysis.Invoke("getPresentValue", cashTransactions, .5));

            cashTransactions.Add(cashTransactionFactory.create(date, amount));

            Assert.AreEqual(1500d, privateCashAnalysis.Invoke("getPresentValue", cashTransactions, .5));
        }
    }
}
