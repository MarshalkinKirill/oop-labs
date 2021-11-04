using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Tools
{
    public class StudentBelongsElectiveModulsFacultyErrorException : Exception
    {
        public StudentBelongsElectiveModulsFacultyErrorException(string msg) : base(msg)
        {
        }
    }
}
