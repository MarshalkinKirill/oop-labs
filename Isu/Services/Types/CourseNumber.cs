namespace Isu.Services.Types
{
    public class CourseNumber
    {
        private string courseNumber;

        public CourseNumber(string _courseNumber)
        {
            courseNumber = _courseNumber;
        }

        public string GetCourseNumber()
        {
            return courseNumber;
        }
    }
}
