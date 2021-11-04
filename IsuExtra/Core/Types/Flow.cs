using System;
using System.Collections.Generic;
using System.Text;
using Isu.Services.Types;
using Isu.Services;

namespace IsuExtra.Core.Types
{
    public class Flow
    {
        public int places;
        private List<Student> students {  get; set; }
        public List<Student> Students { get { return students; } }
        private Schedule schedule {  get; set; }
        public Schedule Schedule { get { return schedule; } }

        public Flow(int _places, Schedule _schadule)
        {
            places = _places;
            schedule = _schadule;
            students = new List<Student>();
        } 

        public void AddStudent(Student _student)
        {
            students.Add(_student);
        }

        public void DeleteStudent(Student _student)
        {
            students.Remove(_student);
        }
    }
}
