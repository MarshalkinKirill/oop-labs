using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Core
{
    public abstract class Repository
    {
        public abstract void AddFilePath(string _filePath);
    }
}
