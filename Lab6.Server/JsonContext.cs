using lab6.DaLayer;
namespace Lab6.Server
{
    public sealed class JsonContext : IJsonContext
    {
        public string employeePath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Employee.dat";
        public string commentPath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Comments.dat";
        public string sprintPath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Sprint.dat";
        public string taskPath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Tasks.dat";
        public string taskLogPath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Taskslog.dat";
        public string reportPath = "C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Reports.dat";
        /*public string employeePath = "Employee.dat";
        public string commentPath = "Comments.dat";
        public string sprintPath = "Sprint.dat";
        public string taskPath = "Tasks.dat";
        public string taskLogPath = "Taskslog.dat";*/
        public InitEmployeeData InitEmployees = new InitEmployeeData("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Employee.dat");
        public ReadEmployeeData ReadEmployees = new ReadEmployeeData();
        public InitCommentData InitComments = new InitCommentData("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Comments.dat");
        public ReadCommentData ReadComments = new ReadCommentData();
        public InitSprintData InitSprintData = new InitSprintData("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Sprint.dat");
        public ReadSprintData ReadSprintData = new ReadSprintData();
        public InitTaskData InitTaskData = new InitTaskData("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Tasks.dat");
        public ReadTaskData ReadTasks = new ReadTaskData();
        public InitTasksLog InitLog = new InitTasksLog("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Taskslog.dat");
        public ReadLogData ReadLog = new ReadLogData();
        public InitReportData InitReports = new InitReportData("C:\\Users\\evilr\\source\\repos\\is-oop-y24\\MarshalkinKirill\\lab6\\bin\\Debug\\netcoreapp3.1\\Reports.dat");
        public ReadReportData ReadReport = new ReadReportData();

        private JsonContext () { }
        
        private static JsonContext instance;

        public static JsonContext GetInstance()
        {
            if (instance == null)
            {
                instance = new JsonContext ();
            }
            return instance;
        }
    }
}
