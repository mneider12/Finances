using Finances.Model.Shared.RecordIdManager;
using System;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransactionFactory
    {
        ICashTransaction create(DateTime date, decimal amount);
    }
}
