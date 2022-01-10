using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Backups.Core.SystemObjects.Types
{
    public class JobObject
    {
        private string filePath { get; set; }
        public string FilePath { get { return filePath; }  }

        public JobObject(string _filePath)
        {
            filePath = _filePath;
        }
    }
}
