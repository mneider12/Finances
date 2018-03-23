using System;

namespace Finances.Model
{
    public interface ICashTransaction : IRecord
    {
        int Id { get; }
        DateTime Date { get; }
        decimal Amount { get; }
    }
}
