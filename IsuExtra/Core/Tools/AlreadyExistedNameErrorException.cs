using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class AlreadyExistedNameErrorException : Exception
    {
        public AlreadyExistedNameErrorException(string msg) : base(msg)
        {
        }
    }
}
