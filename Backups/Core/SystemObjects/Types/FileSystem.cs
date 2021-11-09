using System;
using System.Collections.Generic;
using System.Text;
using Backups.Core.Abstructions;
using System.IO;
using System.IO.Compression;

namespace Backups.Core.SystemObjects.Types
{
    public class FileSystem : Repository
    {
        private string filePath {  get; set; }
        public string FilePath { get { return filePath; } }

        public FileSystem(string _filePath)
        {
            filePath = _filePath;
        }

        public FileSystem()
        {
        }

        public void AddFilePath(string _filePath)
        {
            filePath = _filePath;
        }

        public DirectoryInfo CreateToZipDirectory()
        {
            DirectoryInfo diInfo = Directory.CreateDirectory("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\Backups\\bin\\Debug\\toZip");
            return diInfo;
        }

        public void CopyFilesToDirectory(DirectoryInfo _diInfo, List<JobObject> _jobObjects)
        {
            int k = 0;
            foreach (JobObject jobObject in _jobObjects)
            {
                File.Copy(jobObject.FilePath, _diInfo.FullName + "\\jobObject_" + k.ToString() + Path.GetExtension(jobObject.FilePath));
                k++;
            }
        }

        public void DeleteDirectory(DirectoryInfo _diInfo)
        {
            _diInfo.Delete();
        }
    }
}
