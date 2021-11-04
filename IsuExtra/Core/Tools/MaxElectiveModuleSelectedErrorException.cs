using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class MaxElectiveModuleSelectedErrorException : Exception
    {
        public MaxElectiveModuleSelectedErrorException(string msg) : base(msg)
        {
        }
    }
}
