using Microsoft.AspNetCore.Mvc;
using Lab6.Server.Services;
using lab6.BlLayer;
using System;

namespace Lab6.Server.Controllers
{
    [Route("/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        ReportService reportService = new ReportService(JsonContext.GetInstance());
        [HttpGet]
        [Route("/report/Find")]
        public IActionResult FindById([FromQuery] int id)
        {
            return Ok(reportService.FindById(id));
        }

        [HttpGet]
        [Route("/report/FindByEmployeeId")]
        public IActionResult FindByEmployeeId([FromQuery] int id)
        {
            return Ok(reportService.FindByEmployeeId(id));
        }

        [HttpGet]
        [Route("/report/GetAll")]
        public IActionResult GetAll()
        {
            return Ok(reportService.GetAll());
        }

        [HttpPost]
        [Route("/report/Day")]
        public void CreateReport([FromQuery] int id,[FromQuery] int employeeId)
        {
            reportService.CreateReport(id, employeeId);
        }

        [HttpPost]
        [Route("/report/SprintOrTeamled")]
        public void CreateReport([FromQuery] int id,[FromQuery] int employeeId, [FromQuery] int sprintId, [FromQuery] DateTime start, [FromQuery] DateTime end, bool teamled)
        {
            reportService.CreateReport(id, employeeId, new Sprint(sprintId, start, end), teamled);
        }
        [HttpPut]
        public void AddTaskToReport([FromQuery] int id,[FromQuery] int taskId)
        {
            reportService.AddTaskToReport(id, taskId);
        }
    }
}
