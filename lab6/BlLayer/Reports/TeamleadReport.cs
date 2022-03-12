using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer.Reports
{
	public class TeamleadReport 
	{
		public int EmployeeID { get; set; }
		public List<Task> ReportTasks { get; set; } 
		public DateTime ReportDay { get; set; }
		private ReportStatus Status { get; set; }
		public Sprint ReportSprint { get; set; }
		public List<SprintReport> EmployeesReportList { get; set; }
		public TeamleadReport()
		{

		}
		public TeamleadReport (int employeeid, Sprint sprint)
		{
			EmployeeID = employeeid;
			ReportDay = DateTime.Now.Date;
			Status = ReportStatus.Active;
			ReportSprint = sprint;
			EmployeesReportList = new List<SprintReport>();
			ReportTasks = new List<Task>();
		}
		public void EditTaskToReport(Task task)
		{
			if (ReportSprint.EndDate.Day < DateTime.Now.Day)
			{
				Console.WriteLine("It's too late to edit report");
			}
			else
			{
				ReportTasks.Add(task);
			}
		}
		public void EditEmployeeReport (SprintReport report)
		{
			if (ReportSprint.EndDate.Day < DateTime.Now.Day)
			{
				Console.WriteLine("It's too late to edit report");
			}
			else
			{
				EmployeesReportList.Add(report);
			}
		}
	}
}
