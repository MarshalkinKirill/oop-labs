using Microsoft.AspNetCore.Mvc;
using Lab6.Server.Services;
using lab6.BlLayer;
using System;
namespace Lab6.Server.Controllers
{
    [Route("/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        TaskService taskService = new TaskService(JsonContext.GetInstance());

        [HttpGet]
        [Route("/task/Find")]
        public IActionResult FindById([FromQuery] int id)
        {
            return Ok(taskService.FindById(id));
        }

        [HttpGet]
        [Route("/task/GetAll")]
        public IActionResult GetAll([FromQuery] int id)
        {
            return Ok(taskService.GetAll());
        }

        [HttpGet]
        [Route("/task/FindByTime")]
        public IActionResult FindByTime([FromQuery] DateTime time)
        {
            return Ok(taskService.FindByTime(time));
        }

        [HttpGet]
        [Route("/task/FindByChanges")]
        public IActionResult FindByChanges()
        {
            return Ok(taskService.FindByChanges());
        }

        [HttpGet]
        [Route("/task/FindByImplementorId")]
        public IActionResult FindByImplementorId([FromQuery] int implementorId)
        {
            return Ok(taskService.FindByImplementorId(implementorId));
        }

        [HttpPost]
        public void Create([FromQuery] int id, [FromQuery] int sprintId, [FromQuery] string name, [FromQuery] string description, [FromQuery] int reporterId)
        {
            taskService.CreateTask(id,sprintId, name, description, reporterId);
        }

        [HttpPut]
        [Route("/task/Close")]
        public void Close([FromQuery] int id, [FromQuery] int closerId)
        {
            taskService.Close(id, closerId);
        }

        [HttpPut]
        [Route("/task/AddComment")]
        public void AddComment([FromQuery] int id, [FromQuery] int commentid, [FromQuery] int comentatorId)
        {
            taskService.AddComment(id, commentid, comentatorId);
        }
    }
}
