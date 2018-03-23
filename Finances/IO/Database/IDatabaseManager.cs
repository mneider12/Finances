using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Finances.IO
{
    public interface IDatabaseManager
    {
        SQLiteConnection databaseConnection();
    }
}
