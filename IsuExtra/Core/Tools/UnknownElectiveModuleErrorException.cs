using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class UnknownElectiveModuleErrorException : Exception
    {
        public UnknownElectiveModuleErrorException(string msg) : base(msg)
        {
        }
    }
}
