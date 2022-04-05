using System;
using System.Collections.Generic;
using System.Text;

namespace lab6.BlLayer.Reports
{
    public abstract class AReport
    {
        public int id { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ReportDay { get; set; }
        public List<Task> ReportTasks { get; set; }

        public void EditTaskToReports(Task task)
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
