using System;
using System.Collections.Generic;
using System.Text;
using lab6.BlLayer.Reports;

namespace lab6.BlLayer
{
	class CreateReports
	{
		List<DayReport> DayReports = new List<DayReport>();
		public DayReport CreateDayreport (int employeeid)
		{
			DayReport dayReport = new DayReport(employeeid);
			return dayReport;
		}
		public SprintReport CreateSprintReport (int employeeid, Sprint sprint)
		{
			SprintReport sprintReport = new SprintReport(employeeid, sprint);
			return sprintReport;
		}
		public TeamleadReport CreateTeamLeadReport(int employeeid, Sprint sprint)
		{
			TeamleadReport teamleadReport = new TeamleadReport(employeeid, sprint);
			return teamleadReport;
		}
	}
}
