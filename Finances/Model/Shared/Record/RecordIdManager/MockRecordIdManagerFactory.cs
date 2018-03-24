using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Model
{
    public class MockRecordIdManagerFactory : IRecordIdManagerFactory
    {
        public IRecordIdManager create()
        {
            return new MockRecordIdManager();
        }
    }
}