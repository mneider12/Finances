﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.IO
{
    public interface IFilePathBuilder
    {
        string getPath(ILocalFile file);
    }
}
