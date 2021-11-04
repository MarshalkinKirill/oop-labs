using System;
using System.Collections.Generic;
using System.Text;
using Isu.Services.Types;
using Isu.Services;
using Isu.Tools.Enums;
using IsuExtra.Core.Types;
using IsuExtra.Core.Tools;

namespace IsuExtra.Core
{
    public class IsuExtraService
    {
        private Service IsuGroupService { get; set; }
        public Service GroupService { get { return IsuGroupService; } }
        private List<Faculty> faculties;
        public List<Faculty> Faculty {  get {  return faculties; }  }
        private List<(Group, Schedule)> groupSchadules;

        public IsuExtraService(List<Faculty> _faculties)
        {
            IsuGroupService = new Service();
            faculties = _faculties;
            groupSchadules = new List<(Group, Schedule)>();
        }

        public void AddGroup(GroupName _groupName, Schedule _schadule)
        {
            IsuGroupService.AddGroup(_groupName);
            groupSchadules.Add((IsuGroupService.FindGroup(_groupName), _schadule));
        }

        public void AddStudent(Group _group, string _name)
        {
            IsuGroupService.AddStudent(_group, _name);
        }

        public void AddElectiveModule(Faculty _faculty, string _name, List<Flow> _flows)
        {
            if (!faculties.Contains(_faculty))
            {
                throw new UnknownFacultyErrorException("Unknown faculty");
            }
            foreach (Faculty  faculty in faculties)
            {
                foreach (ElectiveModule electiveModule in faculty.ElectiveModules)
                {
                    if (electiveModule.Name == _name)
                    {
                        throw new AlreadyExistedNameErrorException("Already existed name");
                    }
                    continue;
                }
            }
            _faculty.AddElectiveModule(_name, _flows);
        }

        public bool CompatibilityChecker(Schedule schadule1, Schedule schadule2)
        {
            bool compatibility = true;
            foreach (Lesson class1 in schadule1.Lessons)
            {
                foreach (Lesson class2 in schadule2.Lessons)
                {
                    if (class1.dateTime.Item1 == class2.dateTime.Item1 && class1.dateTime.Item2 == class2.dateTime.Item2)
                    {
                        compatibility = false;
                    }
                }
            }
            return compatibility ? true :  false;
        }

        public int CountStudentElectiveGroups(Student _student)
        {
            int k = 0;
            foreach (Faculty faculty in faculties)
            {
                foreach (ElectiveModule electiveModule in faculty.ElectiveModules)
                {
                    foreach (Flow flow in electiveModule.Flows)
                    {
                        if (flow.Students.Contains(_student))
                        {
                            k++;
                        }
                    }
                }
            }
            return k;
        }

        public Group GetStudentGroup(Student student)
        {
            foreach (Group group in IsuGroupService.GetGroups())
            {
                if (group.GetList().Contains(student))
                {
                    return group;
                }
            }
            throw new UnstudyingStudentErrorException("Student does not study anywhere");

        }

        public Schedule GetGroupSchadule(Group group)
        {
            foreach ((Group, Schedule) groupSchadule in groupSchadules)
            {
                if (groupSchadule.Item1 == group)
                {
                    return groupSchadule.Item2;
                }
            }
            throw new NonSchaduleGroupErrorException("Group have no schadule");
        }
        public Faculty GetFacultyByElectiveModule(ElectiveModule electiveModule)
        {
            foreach (Faculty faculty in faculties)
            {
                if (faculty.ElectiveModules.Contains(electiveModule))
                {
                    return faculty;
                }
            }
            throw new UnknownElectiveModuleErrorException("Unknown elective  module");
        }
        public bool CheckStudentBelongsElectiveModulsFaculty(Student student, ElectiveModule electiveModule)
        {
            Group studentGroup = GetStudentGroup(student);
            Faculty electiveModuleFaculty = GetFacultyByElectiveModule(electiveModule);
            return (studentGroup.GetName().GetFacultyCutName() == electiveModuleFaculty.CutName) ? true : false;
        }

        public bool CheckElcetiveModuleExists(ElectiveModule electiveModule)
        {
            foreach (Faculty faculty in faculties)
            {
                if (faculty.ElectiveModules.Contains(electiveModule))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddStudentToElectiveModule(Student _student, ElectiveModule _electiveModule)
        {
            if (!CheckElcetiveModuleExists(_electiveModule))
            {
                throw new UnknownElectiveModuleErrorException("Unknown elective  module");
            }
            if (CountStudentElectiveGroups(_student) == 2)
            {
                throw new MaxElectiveModuleSelectedErrorException("Student select max elective modules");
            }
            if (CheckStudentBelongsElectiveModulsFaculty(_student, _electiveModule))
            {
                throw new StudentBelongsElectiveModulsFacultyErrorException("Student belongs elective moduls faculty");
            }
            Group studentGroup = GetStudentGroup(_student);
            Schedule groupSchadule = GetGroupSchadule(studentGroup);
            bool checker = false; 
            foreach (Flow flow in _electiveModule.Flows)
            {
                if (CompatibilityChecker(flow.Schedule, groupSchadule) && flow.Students.Count <= flow.places)
                {
                    checker = true;
                    flow.AddStudent(_student);
                    break;
                }
            }
            if (!checker)
            {
                throw new IncompatibleElectiveModuleErrorException("Student cant be add to this elective module");
            }
        }

        public bool CheckElectiveModuleContainsStudent(Student student, ElectiveModule electiveModule)
        {
            foreach (Flow flow in electiveModule.Flows)
            {
                if (flow.Students.Contains(student))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteStudentFromElectiveModule(Student _student, ElectiveModule _electiveModule)
        {
            if (!CheckElcetiveModuleExists(_electiveModule))
            {
                throw new UnknownElectiveModuleErrorException("Unknown elective  module");
            }
            if (!CheckElectiveModuleContainsStudent(_student, _electiveModule))
            {
                throw new ElectiveModuleUnexistStudentErrorException("Elective module does not exist student");
            }
            foreach (Flow flow in _electiveModule.Flows)
            {
                if (flow.Students.Contains(_student))
                {
                    flow.DeleteStudent(_student);
                }
            }
        }

        public List<Flow> GetElectiveModuleFlows(ElectiveModule _electiveModule)
        {
            return _electiveModule.Flows;
        }

        public bool CheckFlowIsReal(Flow flow)
        {
            foreach (Faculty faculty in faculties)
            {
                foreach (ElectiveModule electiveModule in faculty.ElectiveModules)
                {
                    if (electiveModule.Flows.Contains(flow))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<Student> GetFlowStudents(Flow _flow)
        {
            if (!CheckFlowIsReal(_flow))
            {
                throw new UnknownFlowErrorException("Unknown flow");
            }
            return _flow.Students;
        }

        public List<Student> GetUnsignedStudents(Group _group)
        {
            List<Student> groupStudents = IsuGroupService.FindStudents(_group.GetName());
            List<Student> unsignedStudents = new List<Student>();
            foreach (Student student in groupStudents)
            {
                if (CountStudentElectiveGroups(student) == 0)
                {
                    unsignedStudents.Add(student);
                }
            }
            return unsignedStudents;
        }
    }
}
