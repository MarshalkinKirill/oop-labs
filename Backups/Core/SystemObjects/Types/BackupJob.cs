using System;
using System.Collections.Generic;
using System.Text;
using Backups.Core.Abstructions;
using Backups.Core.SystemObjects.Algorithms;

namespace Backups.Core.SystemObjects.Types
{
    public class BackupJob
    {
        private readonly string name;
        private List<JobObject> jobObjects {  get; set; }
        private Backup backup;
        private StorageAlgorithm storageAlgorithm;
        private FileSystem fileSystem;

        public BackupJob(string _name, StorageAlgorithm _storageAlgorithm)
        {
            name = _name;
            storageAlgorithm = _storageAlgorithm;   
            backup = new Backup();
            jobObjects = new List<JobObject>(); 
            fileSystem = new FileSystem();
        }

        public void AddFilePath(string _filesPaths)
        {
            fileSystem.AddFilePath(_filesPaths);
        }

        public void CreateRestorePoint()
        {
            List<Storage> storages = storageAlgorithm.CreateStorage(fileSystem, jobObjects, backup, name);
            backup.AddRestorePoint(storages);
        }

        public void AddJobObject(JobObject _jobObject)
        {
            jobObjects.Add(_jobObject);
        }

        public void DeleteJobObject(JobObject _jobObject)
        {
            jobObjects.Remove(_jobObject);
        }
    }
}
