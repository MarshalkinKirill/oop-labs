using System;
using System.Collections.Generic;
using System.Text;
using lab6.DaLayer;
using lab6.BlLayer;
using lab6.BlLayer.Reports;

namespace lab6.PrLayer
{
	class PrintInfo
	{
		public void PrintEmployeeInfo(Employee employee)
		{
			Console.WriteLine($"ID: {employee.ID}");
			Console.WriteLine($"Name: {employee.Name}");

			Console.WriteLine($"BossID: {employee.Boss}");
			if (employee.SubordinateList != null)
			{
				Console.WriteLine("Subordinates");
				foreach (Employee emp in employee.SubordinateList)
				{
					Console.WriteLine(emp.Name);
				}
			}
			Console.WriteLine($"Employee type: {employee.Type}");
			Console.WriteLine("\n");
		}
		public void PrintAllEmployeeInfo(List<Employee> infolist)
		{
			foreach (Employee employee in infolist)
			{
				PrintEmployeeInfo(employee);
			}
		}
		public void PrintComment(Comment comment)
		{
			Console.WriteLine($"Comment ID: {comment.ID}");
			Console.WriteLine($"EmployeeId: {comment.EmployeeID}");
			Console.WriteLine($"Comment: {comment.Text}");
			Console.WriteLine("\n");
		}
		public void PrintAllComments(List<Comment> comments)
		{
			foreach(Comment comment in comments)
			{
				PrintComment(comment);
			}
		}
		public void PrintSprintInfo(Sprint sprint)
		{
			Console.WriteLine($"SprintID: {sprint.ID}");
			Console.WriteLine($"Sprint StartDate: {sprint.StartDate}");
			Console.WriteLine($"Sprint EndDate: {sprint.EndDate}");
			Console.WriteLine("\n");
		}
		public void PrintAllSprintsInfo(List<Sprint> sprints)
		{
			foreach(Sprint sprint in sprints)
			{
				PrintSprintInfo(sprint);
			}
		}
		public void PrintTaskInfo(Task task)
		{
			Console.WriteLine("Task Info");
			Console.WriteLine($"ID: {task.TaskID}");
			Console.WriteLine($"Sprint ID: {task.SprintID}");
			Console.WriteLine($"Name: {task.Name}");
			Console.WriteLine($"Description: {task.Description}");
			Console.WriteLine($"CreationDate: {task.CreationTime.ToString("d")}");
			Console.WriteLine($"ResolvedDate: {task.ResolvedTime.ToString("d")}");
			Console.WriteLine($"Reporter ID: {task.ReporterID}");
			Console.WriteLine($"Implementer ID: {task.ImplementerID}");
			Console.WriteLine($"Status: {task.Status}");
			Console.WriteLine($"Last Change Date: {task.LastChangeDate.ToString("d")}");
			Console.WriteLine($"Comments");
			foreach(int comment in task.CommentList)
			{
				Console.WriteLine(comment); 
			}
			Console.WriteLine("\n");
		}
		public void PrintAllTasksInfo(List<Task> tasks)
		{
			foreach(Task task in tasks)
			{
				PrintTaskInfo(task);
			}
		}
		public void PrintLogs(List<TaskChange> changes)
		{
			foreach(TaskChange change in changes)
			{
				Console.WriteLine("Change Info");
				Console.WriteLine($"Date of change: {change.ChangeDay}");
				Console.WriteLine($"Task ID: {change.TaskID}");
				Console.WriteLine($"Employee ID: {change.EmployeeID}");
				Console.WriteLine($"Operation: {change.TypeOfChange}");
				if (change.TypeOfChange == OperationType.NewComment)
				{
					Console.WriteLine($"New Comment ID: {change.NewCommentID}");
				}
				if(change.TypeOfChange == OperationType.NewImplementer)
				{
					Console.WriteLine($"New Implementer ID: {change.NewImplementerID}");
				}
				if (change.TypeOfChange == OperationType.NewTaskStatus)
				{
					Console.WriteLine($"New Task Status: {change.NewTaskStatus}");
				}
				Console.WriteLine("\n");
			}
		}
		public void PrintHierarchy (List<Employee> employeelist)
		{
			var teamlead = employeelist.Find(item => item.Type.Equals(EmployeeType.TeamLeader));
			Console.WriteLine("TeamLeader");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(teamlead.Name);
			Console.ResetColor();
			foreach (Employee employee in employeelist)
			{
				if(employee.Type != EmployeeType.SuperVisor)
				{
					continue;
				}
				else
				{
					Console.WriteLine("		Supervisor");
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine($"		{employee.Name}");
					Console.ResetColor();
					if (employee.SubordinateList != null)
					{
						Console.WriteLine($"		{employee.Name} Subordinates");
						foreach (Employee emp in employee.SubordinateList)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine($"			{emp.Name}");
							Console.ResetColor();
						}
					}
				}
			}
			foreach(Employee employee in employeelist)
			{
				if(employee.Type == EmployeeType.BaseEmployee && employee.Boss == 0)
				{
					Console.WriteLine("			Base Employees");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"			{employee.Name}");
					Console.ResetColor();
				}
			}
		}
		public void PrintDayReport (DayReport report)
		{
			Console.WriteLine($"Employee ID: {report.EmployeeID}");
			Console.WriteLine($"Report Day: {report.ReportDay}");
			foreach(Task task in report.ReportTasks)
			{
				PrintTaskInfo(task);
			}
			Console.WriteLine("\n");
		}
		public void PrintSprintReport (SprintReport report)
		{
			Console.WriteLine($"Employee ID: {report.EmployeeID}");
			Console.WriteLine($"Start Day of Sprint: {report.ReportSprint.StartDate}");
			Console.WriteLine($"End Day of Sprint: {report.ReportSprint.EndDate}");
			Console.WriteLine($"Report Day: {report.ReportDay}");
			foreach (Task task in report.ReportTasks)
			{
				PrintTaskInfo(task);
			}
			Console.WriteLine("\n");
		}
	}
}
