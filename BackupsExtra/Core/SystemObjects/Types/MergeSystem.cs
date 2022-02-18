using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.SystemObjects.Types
{
    public class MergeSystem
    {
        public RestorePoint Merge (RestorePoint firstRestorePoint, RestorePoint secondRestorePoint, List<RestorePoint> restorePoints)
        {
            if (!restorePoints.Contains(firstRestorePoint) || !restorePoints.Contains(secondRestorePoint))
            {
                throw new Exception("Restorepoints doesnt contains both points");
            }
            if (firstRestorePoint.Storages.Count == 1)
            {
                DeletePoint(restorePoints, firstRestorePoint);
                return secondRestorePoint;
            }

            foreach (Storage storage in firstRestorePoint.Storages)
            {
                if (secondRestorePoint.Storages.Contains(storage))
                {
                    firstRestorePoint.Storages.Remove(storage);
                }
                else
                {
                    secondRestorePoint.Storages.Add(storage);
                }
            }
            return secondRestorePoint;
        }

        public void DeletePoint(List<RestorePoint> restorePoints, RestorePoint restorePoint)
        {
            restorePoints.Remove(restorePoint);
        }
    }
}
