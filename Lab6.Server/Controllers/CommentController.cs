using Microsoft.AspNetCore.Mvc;
using Lab6.Server.Services;
using lab6.BlLayer;


namespace Lab6.Server.Controllers
{
    [Route("/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService commentService = new CommentService(JsonContext.GetInstance());

        [HttpGet]
        [Route("/comment/Find")]
        public IActionResult Find([FromQuery] int id)
        {
            return Ok(commentService.FindById(id));
        }

        [HttpPost]
        [Route("/comment/Create")]
        public void Create([FromQuery] int id, [FromQuery] int employeeId, [FromQuery] string text)
        {
            commentService.CreateComment(id, employeeId, text);
        }
    }
}
