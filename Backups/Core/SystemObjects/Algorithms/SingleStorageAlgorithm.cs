using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Types;

namespace Backups.Core.SystemObjects.Algorithms
{
    public class SingleStorageAlgorithm : StorageAlgorithm
    {
        public override List<Storage> CreateStorage(FileSystem _fileSystem, List<JobObject> _jobObjects, Backup _backup, string _name)
        {
            List<Storage> storages = new List<Storage>();
            string zipPath = _fileSystem.FilePath + "\\" + _name + "_" + _backup.RestorePoints.Count.ToString() + ".zip";
            DirectoryInfo diInfo = _fileSystem.CreateToZipDirectory();
            _fileSystem.CopyFilesToDirectory(diInfo, _jobObjects);
            ZipFile.CreateFromDirectory(diInfo.FullName, zipPath);
            _fileSystem.DeleteDirectory(diInfo);
            storages.Add(new Storage(zipPath));
            Console.WriteLine("Single storage create successfuly");
            return storages;
        }
    }
}
