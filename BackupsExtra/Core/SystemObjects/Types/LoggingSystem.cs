using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BackupsExtra.Core.Abstructions;

namespace BackupsExtra.Core.SystemObjects.Types
{
    public class LoggingSystem
    {
        private ILog consoleLogger;
        private ILog fileLogger;

        public LoggingSystem() { }
        public LoggingSystem(ILog _fileLogger, ILog _consoleLogger)
        {
            consoleLogger = _consoleLogger;
            fileLogger = _fileLogger;
        }

        public void ConsoleLoggingWithDate(string log)
        {
            consoleLogger.Logging(DateTime.Now + log);
        }

        public void ConsoleLogging(string log)
        {
            consoleLogger.Logging(log);
        }

        public void FileLogging(string log)
        {
            fileLogger.Logging(log);
        }

        public void FileLoggingWithDate(string log)
        {
            fileLogger.Logging(DateTime.Now + log);
        }
    }
}
