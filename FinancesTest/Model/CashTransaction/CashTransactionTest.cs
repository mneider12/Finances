using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finances.Model.Shared;
using Finances.Model.CashTransaction;

namespace FinancesTest.Model.CashTransaction
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class CashTransactionTest
    {
        #region test cases
        /// <summary>
        /// Test creating a cash transaction
        /// Here, the date is 1/1/2000 and the amount is 100.55. 
        /// ID will be 1 supplied by the mock factory
        /// </summary>
        [TestMethod]
        public void createTest()
        {
            ICashTransactionFactory cashTransactionFactory = new MockCashTransactionFactory();

            DateTime jan012000 = new DateTime(2000,1,1);
            Decimal amount = 100.55m;
            ICashTransaction cashTransaction = cashTransactionFactory.create(jan012000, amount);

            Assert.AreEqual(1, cashTransaction.Id);
            Assert.AreEqual(amount, cashTransaction.Amount);
            Assert.AreEqual(jan012000, cashTransaction.Date);
        }
        #endregion
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }    
    }
}
