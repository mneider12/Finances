using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finances.Model;

namespace Finances.Analysis
{
    public class CashAnalysis : ICashAnalysis
    {
        public double getRateOfReturn(List<ICashTransaction> cashTransactions, decimal presentValue)
        {
            return getRateOfReturn(cashTransactions, presentValue, INITIAL_GUESS, INITIAL_INCREMENT);
        }

        private const double INITIAL_GUESS = .05;
        private const double INITIAL_INCREMENT = .0001;
        private const double DAYS_PER_YEAR = 365.25;


        private double getRateOfReturn(List<ICashTransaction> cashTransactions, decimal presentValue, double guess, double increment)
        {
            throw new NotImplementedException(); 
        }

        private double getPresentValue(List<ICashTransaction> cashTransactions, double annualRateOfReturn)
        {
            double totalPresentValue = 0;
            double annualMultiplier = annualRateOfReturn + 1;
            
            foreach (ICashTransaction cashTransaction in cashTransactions)
            {
                double years = DateTime.Today.Subtract(cashTransaction.Date).TotalDays / DAYS_PER_YEAR;
                double cashTransactionPresentValue = Math.Pow((double) cashTransaction.Amount * (annualMultiplier), years);
                totalPresentValue = totalPresentValue + cashTransactionPresentValue;
            }

            return totalPresentValue;
        }
    }
}