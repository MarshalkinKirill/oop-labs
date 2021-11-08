using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class ElectiveModuleUnexistStudentErrorException : Exception
    {
        public ElectiveModuleUnexistStudentErrorException(string msg) : base(msg)
        {
        }
    }
}
