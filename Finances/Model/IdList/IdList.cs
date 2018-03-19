using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Model.IdList
{
    public abstract class IdList
    {
        public abstract Dictionary<int, int> Ids {get; }
        public abstract Dictionary<int, int> load();
        
    }
}