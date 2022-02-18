using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;
using System.IO;

namespace BackupsExtra.Core.SystemObjects.Types.LogTypes
{
    public class FileLogging : ILog
    {
        private string logPath;

        public FileLogging(string _logPath)
        {
            logPath = _logPath;
        }

        public void Logging(string log)
        {
            StreamWriter msg = new StreamWriter(log);
            msg.WriteLine(DateTime.Now + log);
        }
    }
}
