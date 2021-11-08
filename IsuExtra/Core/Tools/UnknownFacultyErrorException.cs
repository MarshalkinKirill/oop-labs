using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class UnknownFacultyErrorException : Exception
    {
        public UnknownFacultyErrorException(string msg) : base(msg)
        {
        }
    }
}
