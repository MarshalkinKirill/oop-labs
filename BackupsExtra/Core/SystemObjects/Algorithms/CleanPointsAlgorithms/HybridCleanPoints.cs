using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;

namespace BackupsExtra.Core.SystemObjects.Algorithms.CleanPointsAlgorithms
{
    public class HybridCleanPoints : ICleanPoints
    {
        private List<ICleanPoints> cleaningAlgorithms = new List<ICleanPoints>();

        public HybridCleanPoints(List<ICleanPoints> _cleaningAlgorithms)
        {
            cleaningAlgorithms = _cleaningAlgorithms;
        }

        public void AddCleaningAlgorithm(ICleanPoints cleaningAlgorithm)
        {
            cleaningAlgorithms.Add(cleaningAlgorithm);
        }

        public List<RestorePoint> Clean(List<RestorePoint> restorePoints, CleaningCondition cleaningCondition)
        {
            foreach (ICleanPoints cleaningAlgorithm in cleaningAlgorithms)
            {
                List<RestorePoint> restoreAlgorithmPoints = cleaningAlgorithm.Clean(restorePoints, cleaningCondition);
                foreach (RestorePoint restorePoint in restorePoints)
                {
                    if (!restoreAlgorithmPoints.Contains(restorePoint))
                    {
                        restorePoints.Remove(restorePoint);
                    }
                }
            }
            return restorePoints;
        }
    }
}
