using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class IncompatibleElectiveModuleErrorException : Exception
    {
        public IncompatibleElectiveModuleErrorException(string msg) : base(msg)
        {
        }
    }
}
