using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Core.Abstuctions;
using Isu.Core.SystemObjects.Types;

namespace Isu.Core.SystemObjects
{
    public class Service : IIsuService
    {
        private List<Group> Groups;
        private int Id;

        public Service()
        {
            Id = 0;
            Groups = new List<Group>();
        }

        public Group AddGroup(GroupName name)
        {
            Group _group = new Group(name);
            Groups.Add(_group);
            return _group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (!Groups.Contains(group))
            {
                throw new Exception("группа не найдена");
            }
            Student _student = group.AddStudent(name, Id++);
            return _student;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in Groups)
            {
                List<Student> _students = group.GetList();
                foreach (Student _student in _students)
                {
                    if (_student.GetId() == id)
                        return _student;
                }
            }
            throw new Exception("незарегистрированный Id");
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in Groups)
            {
                List<Student> _students = group.GetList();
                foreach (Student _student in _students)
                {
                    if (_student.GetName() == name)
                        return _student;
                }
            }
            throw new Exception("незарегистрированное имя");
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            foreach (Group group in Groups)
            {
                if (group.GetName() == groupName)
                {
                    return group.GetList();
                }
            }
            throw new Exception("группа с таким названием не найдена");
        }

        public List<Student> FindStudents(CourseNumber coursenumber)
        {
            List<Student> findedStudents = new List<Student>();
            foreach (Group group in Groups)
            {
                if (group.GetName().GetCourseNumber() == coursenumber)
                {
                    findedStudents = findedStudents.Concat(group.GetList()).ToList();
                }
            }
            return findedStudents;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach(Group group in Groups)
            {
                if (group.GetName() == groupName)
                {
                    return group;
                }
            }
            throw new Exception("группа с таким названием не найдена");
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            List<Group> findedGroups = new List<Group>();
            foreach (Group group in Groups)
            {
                if (group.GetName().GetCourseNumber() == courseNumber)
                {
                    findedGroups.Add(group);
                }
            }
            return findedGroups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (Group group in Groups)
            {
                if (group.GetList().Contains(student))
                {
                    group.DeleteStudent(student);
                    newGroup.AddStudent(student); 
                }
            }
        }
    }
}
