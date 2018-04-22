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
        bool insertOne(string tableName, params object[] values);
        NameValueCollection selectOne(string tableName, int primaryKey);
        bool deleteOne(string tableName, int primaryKey);
        bool create(string createSql);
    }
}
