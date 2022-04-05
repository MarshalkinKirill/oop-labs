using lab6.BlLayer;
using System;

namespace Lab6.Server.Services
{
    public class ReportService
    {
        private JsonContext jsonContext;
        private JsonRepository jsonRepository;

        public ReportService(JsonContext jsonContext)
        {
            jsonRepository = new JsonRepository(jsonContext);
        }

        public string FindById(int id)
        {
            return jsonRepository.FindReportById(id);
        }

        public string FindByEmployeeId(int id)
        {
            return jsonRepository.FindReportEmployeeId(id);
        }
       
        public string GetAll()
        {
            return jsonRepository.GetAllReports();
        }

        public void CreateReport(int id, int employeeId)
        {
            jsonRepository.CreateDayReport(id, employeeId);
        }

        public void CreateReport(int id, int employeeId, Sprint sprint, bool teamlead)
        {
            if (teamlead)
            {
                jsonRepository.CreateTeamleadReport(id, employeeId, sprint);
            }
            else
            {
                jsonRepository.CreateSprintReport(id, employeeId, sprint);
            }
        }

        public void AddTaskToReport(int id, int taskId)
        {
            jsonRepository.AddTaskToReport(id, taskId);
        }
    }
}
