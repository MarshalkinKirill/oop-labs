using System;
using System.Text.RegularExpressions;

namespace Isu.Services.Types
{
    public class GroupName
    {
        private CourseNumber courseNumber;
        private string groupNumber;
        private string facultyCutName;

        public GroupName(string _name)
        {
            if (_name.Length != 5 || !Regex.IsMatch(_name, @"^[A-Z]{1}\d(\d*)"))
            {
                throw new Exception("Неправильный формат названия группы");
            }
            else
            {
                courseNumber = new CourseNumber(_name.Substring(2,1));
                groupNumber = _name.Substring(3,2);
                facultyCutName = _name.Substring(1,1);
            }
        }

        public CourseNumber GetCourseNumber()
        {
            return courseNumber;
        }

        public string GetFacultyCutName()
        {
            return facultyCutName;
        }
    }
}
