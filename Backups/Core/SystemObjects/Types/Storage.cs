using System;
using System.Collections.Generic;
using System.Text;
using Backups.Core.Enums;

namespace Backups.Core.SystemObjects.Types
{
    public class Storage
    {
        private DateTime dateTime;
        private string zipPath {  get; set; }
        public string ZipPath { get { return zipPath; } }
        private StorageType storageType { get; }
        public StorageType StorageType { get { return storageType; } }
        private List<JobObject> jobObjects { get; set; } = new List<JobObject>();
        public List<JobObject> JobObjects { get { return jobObjects; } }

        public Storage(string _zipPath, List<JobObject> _jobObjects, StorageType _storageType)
        {
            zipPath = _zipPath;
            dateTime = DateTime.Now;
            storageType = _storageType;
            jobObjects = _jobObjects;
        }

        public Storage(string _zipPath, JobObject _jobObject, StorageType _storageType)
        {
            zipPath = _zipPath;
            dateTime = DateTime.Now;
            storageType = _storageType;
            jobObjects.Add(_jobObject);
        }

    }
}
