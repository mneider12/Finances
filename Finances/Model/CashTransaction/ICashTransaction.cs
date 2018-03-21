using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Model.CashTransaction
{
    public interface ICashTransaction
    {
        int Id { get; }
        DateTime Date { get; }
        decimal Amount { get; }
    }
}
