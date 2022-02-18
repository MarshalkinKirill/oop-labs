using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Algorithms;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.Abstructions;
using BackupsExtra.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Algorithms.CleanPointsAlgorithms;


namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            
            
            BackupJob backupJob1 = new BackupJob("TextBackup", new SplitStorageAlgorithm());
            backupJob1.AddFilePath("Q:\\backupTests\\repos");

            StateRestoringSystem stateRestoringSystem = new StateRestoringSystem("Q:\\backupTests\\stateRestore\\stateRestore.bat", backupJob1.Backup.RestorePoints);
            
            JobObject obj_1 = new JobObject("Q:\\backupTests\\test1");
            JobObject obj_2 = new JobObject("Q:\\backupTests\\test2");
            JobObject obj_3 = new JobObject("Q:\\backupTests\\test3");

            backupJob1.AddJobObject(obj_1);
            backupJob1.AddJobObject(obj_2);
            backupJob1.AddJobObject(obj_3);

            backupJob1.CreateRestorePoint();
            backupJob1.CreateRestorePoint();

            backupJob1.DeleteJobObject(obj_3);

            backupJob1.CreateRestorePoint();

            MergeSystem mergeSystem = new MergeSystem();
            RestorePoint mergedPoint = mergeSystem.Merge(backupJob1.Backup.RestorePoints[1], backupJob1.Backup.RestorePoints[2], backupJob1.Backup.RestorePoints);
            backupJob1.CreateRestorePoint(mergedPoint);

            stateRestoringSystem.SaveRestorePoints();

            ICleanPoints countCleaner = new CountCleanPoints();
            List<RestorePoint> cleanedPoints = countCleaner.Clean(backupJob1.Backup.RestorePoints, new CleaningCondition(2));
            foreach (RestorePoint point in cleanedPoints)
            {
                Console.WriteLine(point);
            }

        }
    }
}
