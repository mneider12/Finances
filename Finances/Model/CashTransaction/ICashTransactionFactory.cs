using Finances.Model.Shared;
using System;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransactionFactory
    {
        ICashTransaction create(DateTime date, decimal amount);
    }
}
