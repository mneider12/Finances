using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesTest.IO
{
    public class MockDatabaseManagerFactory : IDatabaseManagerFactory
    {
        public IDatabaseManager create()
        {
            throw new NotImplementedException();
        }

        public MockDatabaseManagerFactory()
        {

        }
    }
}
