using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class NonSchaduleGroupErrorException : Exception
    {
        public NonSchaduleGroupErrorException(string msg) : base(msg)
        {
        }
    }
}
