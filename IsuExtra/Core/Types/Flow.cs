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
        private Schadule schadule {  get; set; }
        public Schadule Schadule { get { return schadule; } }

        public Flow(int _places, Schadule _schadule)
        {
            places = _places;
            schadule = _schadule;
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
