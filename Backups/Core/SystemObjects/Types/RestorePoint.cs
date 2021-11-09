using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Core.SystemObjects.Types
{
    public class RestorePoint
    {
        private DateTime dateTime;
        private List<Storage> storages { get; set; }
        public List<Storage> Storages { get {  return storages; } }

        public RestorePoint(List<Storage> _storages)
        {
            storages = _storages;
            dateTime = DateTime.Now;
        }
    }
}
