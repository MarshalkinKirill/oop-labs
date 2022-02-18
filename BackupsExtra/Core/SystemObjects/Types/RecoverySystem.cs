using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using Backups.Core.SystemObjects.Types;
using BackupsExtra.Core.SystemObjects.Types;
using System.IO;
using System.IO.Compression;

namespace BackupsExtra.Core.SystemObjects.Types
{
    public  class RecoverySystem
    {
        private FileSystem fileSystem;

        public RecoverySystem(FileSystem _fileSystem)
        {
            fileSystem = _fileSystem;
        }

        public void RecoveryToOriginalDirectory(RestorePoint restorePoint, string name)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                int counter = 1;
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    string _zipPath = fileSystem.FilePath + "\\" + name + counter.ToString() + ".zip";
                    ZipFile.CreateFromDirectory(jobObject.FilePath, _zipPath);
                    counter++;
                }
            }
        }

        public void RecoveryToDifferentDirectory(RestorePoint restorePoint, string name, string directory)
        {
            foreach (Storage storage in restorePoint.Storages)
            {
                int counter = 1;
                foreach (JobObject jobObject in storage.JobObjects)
                {
                    string _zipPath = directory + "\\" + name + counter.ToString() + ".zip";
                    ZipFile.CreateFromDirectory(jobObject.FilePath, _zipPath);
                    counter++;
                }
            }
        }
    }
}
