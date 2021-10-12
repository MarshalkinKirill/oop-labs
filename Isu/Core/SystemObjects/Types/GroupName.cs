using System;
using System.Text.RegularExpressions;

namespace Isu.Core.SystemObjects.Types
{
    public class GroupName
    {
        private CourseNumber courseNumber;
        private string groupNumber;

        public GroupName(string _name)
        {
            if (_name.Length != 5 || !Regex.IsMatch(_name, @"^M3(\d*)"))
            {
                throw new Exception("Неправильный формат названия группы");
            }
            else
            {
                courseNumber = new CourseNumber(_name.Substring(2,1));
                groupNumber = _name.Substring(3,2);
            }
        }

        public CourseNumber GetCourseNumber()
        {
            return courseNumber;
        }
    }
}
