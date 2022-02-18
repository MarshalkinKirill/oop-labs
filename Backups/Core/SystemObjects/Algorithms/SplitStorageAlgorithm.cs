using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Types;

namespace Backups.Core.SystemObjects.Algorithms
{
    public class SplitStorageAlgorithm : StorageAlgorithm
    {
        public override List<Storage> CreateStorage(FileSystem _fileSystem, List<JobObject> _jobObjects, Backup _backup, string _name)
        {
            List<Storage> storages = new List<Storage>();
            int k = 0;
            foreach (JobObject jobObject in _jobObjects)
            {
                string zipPath = _fileSystem.FilePath + "\\" + _name + "_" + _backup.RestorePoints.Count.ToString() + "_" + k.ToString() + ".zip";
                k++;
                ZipFile.CreateFromDirectory(jobObject.FilePath, zipPath);
                storages.Add(new Storage(zipPath, jobObject, Enums.StorageType.Split));
            }
            return storages;
        }
    }
}
