using lab6.BlLayer;
using System;
using System.Text;
using System.Collections.Generic;
using lab6.BlLayer.Reports;
namespace Lab6.Server
{
    public class JsonRepository
    {
        private JsonContext jsonContext;

        public JsonRepository(JsonContext context)
        {
            jsonContext = context;
        }

        public string GetAllEmployees()
        {
            return jsonContext.ReadEmployees.ReadEmployeData(jsonContext.employeePath).ToArray().ToString();
        }

        public string GetEmployeeById(int id)
        {
            return jsonContext.ReadEmployees.ReadEmployeData(jsonContext.employeePath).Find(item => item.ID.Equals(id)).ToString();
        }

        public void CreateEmployee(string name, int type)
        {
            if (type == 0)
            {
                jsonContext.InitEmployees.AddEmployee(new Employee((jsonContext.InitEmployees.GetCount() + 1), name, EmployeeType.TeamLeader));
            }
            if (type == 1)
            {
                jsonContext.InitEmployees.AddEmployee(new Employee((jsonContext.InitEmployees.GetCount() + 1), name, EmployeeType.SuperVisor));
            }
            if (type == 2)
            {
                jsonContext.InitEmployees.AddEmployee(new Employee((jsonContext.InitEmployees.GetCount() + 1), name, EmployeeType.BaseEmployee));
            }
        }

        public void UpdateEmployee(int id, string name, EmployeeType type)
        {
            jsonContext.InitEmployees.UpdateEmployee(id, new Employee(jsonContext.InitEmployees.GetCount() + 1, name, type));
        }

        public string GetAllTasks()
        {
            return jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).ToArray().ToString();
        }

        public string FindTaskById(int id)
        {
            return jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).Find(item => item.TaskID.Equals(id)).ToString();
        }

        public string FindTaskByTime(DateTime time)
        {
            return jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).Find(item => item.CreationTime.Equals(time)).ToString();
        }

        public string FindTaskByChanges()
        {
            List<Task> changedTasks = new List<Task>();
            foreach (Task task in jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath))
            {
                if (task.TaskChanges.Count != 0)
                {
                    changedTasks.Add(task);
                }
            }
            return changedTasks.ToArray().ToString();  
        }

        public string FindTaskByImplementorId(int id)
        {
            return jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).FindAll(item => item.ImplementerID.Equals(id)).ToArray().ToString();
        }

        public void CloseTask(int id, int closerId)
        {
            jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).Find(item => item.TaskID.Equals(id)).CloseTask(closerId);
        }

        public void AddCommentToTask(int id, int commentId, int  commentatorId)
        {
            jsonContext.ReadTasks.ReadTasksData(jsonContext.taskPath).Find(item => item.TaskID.Equals(id)).AddComment(commentId, commentatorId);
        }

        public void CreateTask(int id, int sprintId, string name, string description, int reporterId)
        {
            jsonContext.InitTaskData.AddTask(new Task(id, sprintId, name, description, reporterId));
        }

        public string FindReportById(int id)
        {
            return jsonContext.ReadReport.ReadReportsData(jsonContext.reportPath).Find(item => item.id.Equals(id)).ToString();
        }

        public string FindReportEmployeeId(int id)
        {
            return jsonContext.ReadReport.ReadReportsData(jsonContext.reportPath).FindLast(item => item.EmployeeID.Equals(id)).ToString();
        }

        public string GetAllReports()
        {
            return jsonContext.ReadReport.ReadReportsData(jsonContext.reportPath).ToArray().ToString();
        }

        public void CreateDayReport(int id, int employeeId)
        {
            jsonContext.InitReports.AddReport(new DayReport(id, employeeId));
        }

        public void CreateSprintReport(int id, int employeeId, Sprint sprint)
        {
            jsonContext.InitReports.AddReport(new SprintReport(id, employeeId, sprint));
        }

        public void CreateTeamleadReport(int id, int employeeId, Sprint sprint)
        {
            jsonContext.InitReports.AddReport(new TeamleadReport(id, employeeId, sprint));
        }

        public void AddTaskToReport(int id, int taskId)
        {
            jsonContext.ReadReport.ReadReportsData(jsonContext.reportPath).Find(item => item.id.Equals(id)).EditTaskToReports(jsonContext.ReadTasks.ReadTasksData(jsonContext.commentPath).Find(item => item.TaskID.Equals(taskId)));
        }

        public string FindCommentById(int id)
        {
            return jsonContext.ReadComments.ReadComentsData(jsonContext.commentPath).Find(item => item.ID.Equals(id)).Text;
        }

        public void CreateComment(int id, int employeeId, string text)
        {
            jsonContext.InitComments.AddComment(new Comment(id, employeeId, text));
        }
    }
}
