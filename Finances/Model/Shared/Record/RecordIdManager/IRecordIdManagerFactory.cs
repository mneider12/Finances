using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Model
{
    public interface IRecordIdManagerFactory
    {
        IRecordIdManager create();
    }
}
