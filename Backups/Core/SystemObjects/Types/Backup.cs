using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Core.SystemObjects.Types
{
    public class Backup
    {
        private List<RestorePoint> restorePoints {  get; set; }
        public List<RestorePoint> RestorePoints { get { return restorePoints; } }
        public Backup()
        {
            restorePoints = new List<RestorePoint>();
        }

        public void AddRestorePoint(List<Storage> _storages)
        {
            restorePoints.Add(new RestorePoint(_storages));
        }
    }
}
