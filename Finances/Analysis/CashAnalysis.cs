using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finances.Model;

namespace Finances.Analysis
{
    /// <summary>
    /// cash analysis business logic
    /// </summary>
    public class CashAnalysis : ICashAnalysis
    {
        /// <summary>
        /// get the annual rate of return for a list of cash transactions
        /// </summary>
        /// <param name="cashTransactions">list of cash transactions</param>
        /// <param name="presentValue">current value of the portfolio funded by the cash transactions</param>
        /// <returns>the annual rate of return.
        ///          for each cash transaction, the rate of return is defined as:
        ///          PV = A * (1 + r) ^ y
        ///          where:
        ///          PV = present value
        ///          A = original amount (Amount property of cash transaction)
        ///          r = rate of return
        ///          y = number of years from transaction date to today
        /// </returns>
        public double getRateOfReturn(List<ICashTransaction> cashTransactions, double presentValue)
        {
            double lastGuessRateOfReturn = INITIAL_GUESS_RATE_OF_RETURN;
            double lastGuessPresentValue = getPresentValue(cashTransactions, lastGuessRateOfReturn);
            double lastGuessError = presentValue - lastGuessPresentValue;

            while (true)
            {
                double newGuessRateOfReturn;
                if (lastGuessError < 0)
                {
                    newGuessRateOfReturn = lastGuessRateOfReturn - INITIAL_INCREMENT_RATE_OF_RETURN;
                }
                else
                {
                    newGuessRateOfReturn = lastGuessRateOfReturn + INITIAL_INCREMENT_RATE_OF_RETURN;
                }

                double newGuessPresentValue = getPresentValue(cashTransactions, newGuessRateOfReturn);
                double newGuessError = presentValue - newGuessPresentValue;

                if (newGuessError > lastGuessError)
                {
                    return Math.Round(lastGuessRateOfReturn,2);
                }
                else
                {
                    lastGuessRateOfReturn = newGuessRateOfReturn;
                    lastGuessPresentValue = newGuessPresentValue;
                    lastGuessError = newGuessError;
                }
            }
        }

        private const double INITIAL_GUESS_RATE_OF_RETURN = .05;
        private const double INITIAL_INCREMENT_RATE_OF_RETURN = .0001;
        private const double DAYS_PER_YEAR = 365.25;

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