using Microsoft.AspNetCore.Mvc;
using Lab6.Server.Services;
using lab6.BlLayer;

namespace Lab6.Server.Controllers
{
    [Route("/empoyee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService employeeService = new EmployeeService(JsonContext.GetInstance());

        [HttpGet]
        [Route("/empoyee/Find")]
        public IActionResult Find([FromQuery] int id)
        {
            return Ok(employeeService.FindById(id));
        }

        [HttpGet]
        [Route("/empoyee/GetAll")]
        public IActionResult GetAll([FromQuery] int id)
        {
            return Ok(employeeService.GetAll());
        }

        [HttpPost]
        public void Create([FromQuery] string name, [FromQuery] int type)
        {
            employeeService.CreateEmployee(name, type);
        }

        [HttpPut]
        public void Update([FromQuery] int id, [FromQuery] string name, [FromQuery] EmployeeType type)
        {
            employeeService.UpdateEmployee(id, name, type);
        }
    }
}
