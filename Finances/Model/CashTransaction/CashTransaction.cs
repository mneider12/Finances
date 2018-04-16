using Finances.IO;
using System;

namespace Finances.Model
{
    /// <summary>
    /// Represent a "cash" transaction
    /// A cash transaction is a deposit or withdrawl (withdrawls have negative amounts, deposits have positive amounts)
    /// </summary>
    public class CashTransaction : ICashTransaction
    {
        #region ICashTransaction members
        /// <summary>
        /// internal unique identifier
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
        }
        /// <summary>
        /// date the transaction occured
        /// </summary>
        public DateTime Date
        {
            get
            {
                return date;
            }
        }
        /// <summary>
        /// amount of the transaction.
        /// negative amounts indicate withdrawls
        /// </summary>
        public decimal Amount
        {
            get
            {
                return amount;
            }
        }
        #endregion
        #region constructors
        public CashTransaction(IRecordIdManager recordManager, DateTime date, decimal amount)
        {
            this.id = recordManager.getNextId(RecordType.CashTransaction);
            this.date = date;
            this.amount = amount;
        }
        #endregion

        #region private class variables
        private int id;
        private DateTime date;
        private decimal amount;
        #endregion
    }
}