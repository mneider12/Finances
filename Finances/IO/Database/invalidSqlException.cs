using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class invalidSqlException : Exception
    {
        public invalidSqlException() : base() { }
        public invalidSqlException(string message) : base(message) { }
        public invalidSqlException(string message, Exception inner) : base(message, inner) { }
    }
}