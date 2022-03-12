using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer.Reports
{
	public class SprintReport 
	{
		public int EmployeeID { get; set; }
		public DateTime ReportDay { get; set; }
		private ReportStatus Status { get; set; }
		public List<Task> ReportTasks { get; set; }
		public Sprint ReportSprint { get; set; }
		public SprintReport()
		{

		}
		public SprintReport (int employeeid, Sprint reportsprint)
		{
			EmployeeID = employeeid;
			ReportDay = DateTime.Now.Date;
			ReportSprint = reportsprint;
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
		public void EditSubordinatesReports (SprintReport report)
		{
				foreach(Task task in report.ReportTasks)
				{
					ReportTasks.Add(task);
				}
		}
	}
}
