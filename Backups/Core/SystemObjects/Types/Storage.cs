using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Core.SystemObjects.Types
{
    public class Storage
    {
        private DateTime dateTime;
        private string zipPath {  get; set; }
        public string ZipPath { get { return zipPath; } }

        public Storage(string _zipPath)
        {
            zipPath = _zipPath;
            dateTime = DateTime.Now;
        }

    }
}
