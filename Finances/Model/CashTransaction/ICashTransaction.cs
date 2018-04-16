using System;

namespace Finances.Model
{
    public interface ICashTransaction
    {
        int Id { get; }
        DateTime Date { get; }
        decimal Amount { get; }
    }
}
