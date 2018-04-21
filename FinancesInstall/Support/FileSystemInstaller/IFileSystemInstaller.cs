﻿using Finances.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesInstall.Support
{
    public interface IFileSystemInstaller
    {
        IFileSystemManager run();
    }
}
