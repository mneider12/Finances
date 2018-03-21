using System;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransaction
    {
        int Id { get; }
        DateTime Date { get; }
        decimal Amount { get; }
    }
}
