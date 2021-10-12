using Isu.Core.Enums;

namespace Isu.Core.SystemObjects.Types
{
    public class Student
    {
        private readonly int id;
        private readonly string name;
        private Status status;

        public Student(int _id, string _name)
        {
            this.id = _id;
            this.name = _name;
        }

        public Status GetStatus()
        {
            return this.status;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetName()
        {
            return this.name;
        }

        public void ChangeStatus()
        {
            if (this.status == Status.Studying)
            {
                status = Status.UnStudying;
            }
            else
            {
                status = Status.Studying;
            }
        }
    }
}
