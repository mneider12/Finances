using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.IO
{
    public class InvalidSqlException : Exception
    {
        public InvalidSqlException() : base() { }
        public InvalidSqlException(string message) : base(message) { }
        public InvalidSqlException(string message, Exception inner) : base(message, inner) { }
    }
}