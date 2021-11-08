using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class UnknownFlowErrorException : Exception
    {
        public UnknownFlowErrorException(string msg) : base(msg)
        {
        }
    }
}
