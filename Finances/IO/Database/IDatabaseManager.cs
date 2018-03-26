using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.Specialized;

namespace Finances.IO
{
    public interface IDatabaseManager
    {
        bool insert(string tableName, params object[] values);
        List<NameValueCollection> select(string tableName, int primaryKey);
        bool delete(string tableName, int primaryKey);
        bool create(string createSql);
    }
}
