using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Algorithms;
using Backups.Core.SystemObjects.Types;

namespace Backups.Tests
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void Test1()
        {
            BackupJob backupJob1 = new BackupJob("TextBackup", new SingleStorageAlgorithm());
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
            Assert.AreEqual(backupJob1.Backup.RestorePoints.Count, 3);
            Assert.AreEqual(backupJob1.Backup.RestorePoints[2].Storages.Count, 2);
        }
    }
}
