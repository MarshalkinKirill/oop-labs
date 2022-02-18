using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.SystemObjects.Algorithms.CleanPointsAlgorithms
{
    public class VariantCleanPoints : ICleanPoints
    {
        public List<RestorePoint> Clean(List<RestorePoint> restorePoints, CleaningCondition cleaningCondition)
        {
            List<RestorePoint> DateLimitedPoints = restorePoints;
            foreach (RestorePoint restorePoint in DateLimitedPoints)
            {
                if (restorePoint.DateTime > cleaningCondition.Time)
                {
                    DateLimitedPoints.Remove(restorePoint);
                }
            }

            List<RestorePoint> CountLimitedPoints = restorePoints;
            while (cleaningCondition.Counter < CountLimitedPoints.Count)
            {
                CountLimitedPoints.Remove(restorePoints[0]);
            }

            foreach (RestorePoint restorePoint in restorePoints)
            {
                if (DateLimitedPoints.Contains(restorePoint) || CountLimitedPoints.Contains(restorePoint))
                {
                    restorePoints.Remove(restorePoint);
                }
            }

            return restorePoints;
        }
    }
}
