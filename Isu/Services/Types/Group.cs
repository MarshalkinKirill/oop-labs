using System;
using System.Collections.Generic;
using Isu.Tools.Enums;

namespace Isu.Services.Types
{
    public class Group
    {
        private readonly GroupName groupName;
        private List<Student> students;

        public Group(GroupName _groupName, List<Student> _students)
        {
            this.groupName = _groupName;
            this.students = _students;
        }

        public  Group(GroupName _groupName)
        {
            this.groupName = _groupName;
            this.students = new List<Student>();
            students.Capacity = 3;
        }

        public void AddStudent(Student _student)
        {   
            if (_student.GetStatus() == Status.Studying)
            {
                throw new Exception("Ученик уже обучается");
            }
            else
            {
                if (students.Capacity == students.Count)
                {
                    throw new Exception("Привышен лимит учеников");
                }
                _student.ChangeStatus();
                students.Add(_student);
            }
        }
        
        public Student AddStudent(string _studentName, int _id)
        {
            if (students.Capacity == students.Count)
            {
                throw new Exception("Привышен лимит учеников");
            }
            Student _student = new Student(_id, _studentName);
            students.Add(_student);
            return _student;    
        }
        public Student DeleteStudent(Student _student)
        {
            students.Remove(_student);
            _student.ChangeStatus();
            return _student;
        }

        public List<Student> GetList()
        {
            return students;
        }

        public GroupName GetName()
        {
            return groupName;
        }
    }
}
