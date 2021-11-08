using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class UnstudyingStudentErrorException : Exception
    {
        public UnstudyingStudentErrorException(string msg) : base(msg)
        {
        }
    }
}
