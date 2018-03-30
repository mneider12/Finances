using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finances.Model;

namespace Finances.Analysis
{
    public class CashAnalysis : ICashAnalysis
    {
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