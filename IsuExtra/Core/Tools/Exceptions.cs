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
    public class AlreadyExistedNameErrorException : Exception
    {
        public AlreadyExistedNameErrorException(string msg) : base(msg)
        {
        }
    }
    public class UnstudyingStudentErrorException : Exception
    {
        public UnstudyingStudentErrorException(string msg) : base(msg)
        {
        }
    }
    public class NonSchaduleGroupErrorException : Exception
    {
        public NonSchaduleGroupErrorException(string msg) : base(msg)
        {
        }
    }
    public class UnknownElectiveModuleErrorException : Exception
    {
        public UnknownElectiveModuleErrorException(string msg) : base(msg)
        {
        }
    }
    public class MaxElectiveModuleSelectedErrorException : Exception
    {
        public MaxElectiveModuleSelectedErrorException(string msg) : base(msg)
        {
        }
    }
    public class IncompatibleElectiveModuleErrorException : Exception
    {
        public IncompatibleElectiveModuleErrorException(string msg) : base(msg)
        {
        }
    }
    public class ElectiveModuleUnexistStudentErrorException : Exception
    {
        public ElectiveModuleUnexistStudentErrorException(string msg) : base(msg)
        {
        }
    }
    public class UnknownFlowErrorException : Exception
    {
        public UnknownFlowErrorException(string msg) : base(msg)
        {
        }
    }
    public class StudentBelongsElectiveModulsFacultyErrorException : Exception
    {
        public StudentBelongsElectiveModulsFacultyErrorException(string msg) : base(msg)
        {
        }
    }
}
