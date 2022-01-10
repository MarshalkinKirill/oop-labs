using System;
using System.Collections.Generic;
using System.Text;
using Backups.Core.SystemObjects.Types;

namespace Backups.Core.Abstructions
{
    public abstract class StorageAlgorithm
    {
        public abstract List<Storage> CreateStorage(FileSystem _fileSystem, List<JobObject> _jobObjects, Backup _backup, string _name);
    }
}
