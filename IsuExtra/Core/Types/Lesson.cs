using System;
using System.Collections.Generic;
using System.Text;
using Isu.Services.Types;

namespace IsuExtra.Core.Types
{
    public class Lesson
    {
        public Group group {  get; set; }
        public (string, string) dateTime {  get; set; }    
        public Mentor mentor {  get; set; }
        public int classNumber {  get; set; }
        public string electiveGroupNumber { get; set; }

        public Lesson(Group _group, (string, string) _datetime, Mentor _mentor, int _classnumber)
        {
            group = _group;
            dateTime = _datetime;
            mentor = _mentor;
            classNumber = _classnumber;
        }

        public Lesson(string _electiveGroupNumber, (string, string) _datetime, Mentor _mentor, int _classnumber)
        {
            electiveGroupNumber = _electiveGroupNumber;
            dateTime = _datetime;
            mentor = _mentor;
            classNumber = _classnumber;
        }

    }
}
