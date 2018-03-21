using Finances.Model.RecordIdManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        #region constructors
        public CashTransaction(IRecordIdManager recordManager, DateTime date, decimal amount)
        {
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