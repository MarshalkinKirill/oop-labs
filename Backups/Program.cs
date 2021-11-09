using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Algorithms;
using Backups.Core.SystemObjects.Types;

namespace Backups
{
    public class Program
    {
        private static void Main()
        {
            BackupJob backupJob1 = new BackupJob("TextBackup", new SplitStorageAlgorithm());
            backupJob1.AddFilePath("Q:\\backupTests\\repos");
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
        }
    }
}
