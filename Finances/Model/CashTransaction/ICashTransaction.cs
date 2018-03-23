using Finances.Model.Shared.Record;
using System;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransaction : IRecord
    {
        int Id { get; }
        DateTime Date { get; }
        decimal Amount { get; }
    }
}
