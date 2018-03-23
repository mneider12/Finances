using Finances.IO;
using Finances.Model.Shared;
using System;

namespace Finances.Model.CashTransaction
{
    public class CashTransaction : ICashTransaction
    {
        #region ICashTransaction members
        public int Id
        {
            get
            {
                return id;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
        }
        #endregion
        #region IRecord members
        public bool save(IDatabaseManager databaseManager)
        {
            return true;
        }
        #endregion

        #region constructors
        public CashTransaction(IRecordIdManager recordManager, DateTime date, decimal amount)
        {
            this.id = recordManager.getNextId(Shared.RecordType.CashTransaction);
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