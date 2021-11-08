using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Core.Types
{
    public class Schedule
    {
        private List<Lesson> lessons {  get; set; }
        public List<Lesson> Lessons { get { return lessons; } }
        public Schedule()
        {
            List<Lesson> lessons = new List<Lesson>();
        }

        public Schedule(List<Lesson> _lessons)
        {
            lessons = _lessons;
        }

        public void AddClasses(List<Lesson> _lessons)
        {
            lessons = _lessons;
        }
    }
}
