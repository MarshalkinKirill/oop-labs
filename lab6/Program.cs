using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using lab6.PrLayer;
using lab6.DaLayer;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab6.BlLayer;
using lab6.BlLayer.Reports;

namespace lab6
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = "Employees.dat";
			InitEmployeeData InitEmployees = new InitEmployeeData(path);
			ReadEmployeeData ReadEmployees = new ReadEmployeeData();
			PrintInfo printinfo = new PrintInfo();
			var Employeelist = ReadEmployees.ReadEmployeData(path);
			Console.WriteLine("Информация о сотрудниках");
			printinfo.PrintAllEmployeeInfo(ReadEmployees.ReadEmployeData(path));

			Console.WriteLine("Комментарии");
			string commentspath = "Comments.dat";
			InitCommentData InitComments = new InitCommentData(commentspath);
			ReadCommentData ReadComments = new ReadCommentData();
			var OurCommentsList = ReadComments.ReadComentsData(commentspath);
			printinfo.PrintAllComments(ReadComments.ReadComentsData(commentspath));

			string sprintpath = "Sprint.dat";
			InitSprintData InitSprintData = new InitSprintData(sprintpath);
			ReadSprintData ReadSprintData = new ReadSprintData();
			var OurSprintsList = ReadSprintData.ReadTSprintsData(sprintpath);
			printinfo.PrintAllSprintsInfo(ReadSprintData.ReadTSprintsData(sprintpath));

			string taskspath = "Tasks.dat";
			InitTaskData InitTaskData = new InitTaskData(taskspath);
			ReadTaskData ReadTasks = new ReadTaskData();
			string logpath = "Taskslog.dat";
			InitTasksLog InitLog = new InitTasksLog(logpath);
			ReadLogData ReadLog = new ReadLogData();

			Console.WriteLine("Задача и ее изменения");
			printinfo.PrintAllTasksInfo(ReadTasks.ReadTasksData(taskspath));
			var tasklist = ReadTasks.ReadTasksData(taskspath);
			var Ourtask = tasklist[0];
			Ourtask.AppointImplementer(2, 1);
			Ourtask.ChangeImplementer(3, 1);
			Ourtask.CloseTask(1);
			InitTaskData.UpdateTask(123, tasklist[0]);

			Console.WriteLine("Изменения задачи");
			InitLog.AddLog(tasklist[0].TaskChanges);
			printinfo.PrintTaskInfo(ReadTasks.ReadTasksData(taskspath)[0]);
			printinfo.PrintLogs(ReadLog.ReadLogsData(logpath));

			Console.WriteLine("Добавление сотрудникам босса");
			var ArmenEmployeelist = new List<Employee>();
			Employeelist[1].AddBoss(6);
			Employeelist[2].AddBoss(6);
			ArmenEmployeelist.Add(Employeelist[1]);
			ArmenEmployeelist.Add(Employeelist[2]);
			InitEmployees.UpdateEmployee(2, Employeelist[1]);
			InitEmployees.UpdateEmployee(3, Employeelist[2]);
			Employee Armen = new Employee(6, "Armen", ArmenEmployeelist, EmployeeType.SuperVisor);
			InitEmployees.AddEmployee(Armen);
			printinfo.PrintAllEmployeeInfo(ReadEmployees.ReadEmployeData(path));
			InitSprintData.AddSprint(new Sprint(222, new DateTime(2022, 3, 11), new DateTime(2022, 3, 13)));
			InitTaskData.AddTask(new Task(121, 222, "Task2", "do something", 1));
			printinfo.PrintAllSprintsInfo(ReadSprintData.ReadTSprintsData(sprintpath));
			printinfo.PrintAllTasksInfo(ReadTasks.ReadTasksData(taskspath));
			var Employeelist1 = ReadEmployees.ReadEmployeData(path);
			Console.WriteLine("Иерархия");
			printinfo.PrintHierarchy(Employeelist1);
			TaskSystem taskSystem = new TaskSystem(ReadTasks.ReadTasksData(taskspath));
			printinfo.PrintTaskInfo(taskSystem.SearchTaskByID(123));
			DateTime searchtime = ReadTasks.ReadTasksData(taskspath)[0].CreationTime;
			printinfo.PrintTaskInfo(taskSystem.SearchTaskByCreationDate(new DateTime(2022, 3, 12)));
			printinfo.PrintAllTasksInfo(taskSystem.SearchTaskByImplementer(3));
			Console.WriteLine("Методы системы");
			Console.WriteLine("\n");
			var testtask = taskSystem.CreateTask(122, 222, "Task3", "fortest", 1);
			InitTaskData.AddTask(testtask);
			Console.WriteLine("Изменение статуса");
			taskSystem.ChangeTaskStatus(122, TaskStatus.Resolved, 1);
			Console.WriteLine("Назначение и замена сотрудника");
			taskSystem.AppointTaskImplementer(122, 2, 1);
			taskSystem.ChangeTaskImplementer(122, 3, 1);
			Console.WriteLine("Добавление комментария");
			taskSystem.AddCommentToTask(122, 11, 3);
			printinfo.PrintAllTasksInfo(taskSystem.SearchChangedTasks());
			Console.WriteLine("Поиск по дате изменения");
			Console.WriteLine("\n");
			printinfo.PrintTaskInfo(taskSystem.SearchTaskByChangeDate(new DateTime(2022, 3, 12)));
			printinfo.PrintAllTasksInfo(taskSystem.GetSubordinatesTasks(Armen));
			Console.WriteLine("Отчеты");
			Console.WriteLine("\n");
			CreateReports createReports = new CreateReports();
			DayReport report1 = createReports.CreateDayreport(2);
			report1.EditTaskToReport(ReadTasks.ReadTasksData(taskspath)[0]);
			//createReports.CreateDayreport(2).EditTaskToReport(ReadTasks.ReadTasksData(taskspath)[0]);
			printinfo.PrintDayReport(report1);
			SprintReport report2 = createReports.CreateSprintReport(2, ReadSprintData.ReadTSprintsData(sprintpath)[0]);
			report2.EditTaskToReport(ReadTasks.ReadTasksData(taskspath)[0]);
			printinfo.PrintSprintReport(report2);
			SprintReport report3 = createReports.CreateSprintReport(6, ReadSprintData.ReadTSprintsData(sprintpath)[0]);
			report3.EditSubordinatesReports(report2);
			printinfo.PrintSprintReport(report3);
			TeamleadReport report4 = createReports.CreateTeamLeadReport(1, ReadSprintData.ReadTSprintsData(sprintpath)[0]);
			report4.EditEmployeeReport(report3);
			printinfo.PrintSprintReport(report3);
		}
	}
}