using System;
using System.Collections.Generic;
using System.Text;
using BackupsExtra.Core.Abstructions;

namespace BackupsExtra.Core.SystemObjects.Types.LogTypes
{
    public class ConsoleLogging : ILog
    {
        public void Logging(string log)
        {
            Console.WriteLine(log);
        }
    }
}
