using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.SystemObjects.Algorithms.CleanPointsAlgorithms
{
    public class DateCleanPoints : ICleanPoints
    {
        public List<RestorePoint> Clean(List<RestorePoint> restorePoints, CleaningCondition cleaningCondition)
        {
            foreach (RestorePoint restorePoint in restorePoints)
            {
                if (restorePoint.DateTime > cleaningCondition.Time)
                {
                    restorePoints.Remove(restorePoint);
                }
            }
            return restorePoints;
        }
    }
}
