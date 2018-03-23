using System;

namespace Finances.Model
{
    public interface ICashTransactionFactory
    {
        ICashTransaction create(DateTime date, decimal amount);
    }
}
