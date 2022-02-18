using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.SystemObjects.Algorithms.CleanPointsAlgorithms
{
    public class CountCleanPoints : ICleanPoints
    {
        public List<RestorePoint> Clean(List<RestorePoint> restorePoints, CleaningCondition cleaningCondition)
        {
            while (cleaningCondition.Counter < restorePoints.Count)
            {
                restorePoints.Remove(restorePoints[0]);
            }
            return restorePoints;
        }
    }
}
