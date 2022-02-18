using System;
using System.Collections.Generic;
using System.Text;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.Abstructions
{
    public interface ICleanPoints
    {
        public List<RestorePoint> Clean(List<RestorePoint> restorePoints, CleaningCondition cleaningCondition);
    }
}
