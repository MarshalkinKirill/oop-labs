using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer.Reports
{
	public class DayReport 
	{
		public int EmployeeID { get; set; }
		public DateTime ReportDay { get; set; }
		public List<Task> ReportTasks { get; set; }
		private ReportStatus Status { get; set; }
		public DayReport()
		{

		}
		public DayReport(int employeeid)
		{
			EmployeeID = employeeid;
			ReportDay = DateTime.Now.Date;
			Status = ReportStatus.Active;
			ReportTasks = new List<Task>();
		}
		public void EditTaskToReport(Task task)
		{
			if (ReportDay.Day < DateTime.Now.Day)
			{
				Console.WriteLine("It's too late to edit report");
			}
			else
			{
				ReportTasks.Add(task);
			}
		}
	}
}
