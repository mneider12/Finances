﻿using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Model.Shared.Record
{
    public interface IRecord
    {
        bool save(IDatabaseManager databaseManager);
    }
}
