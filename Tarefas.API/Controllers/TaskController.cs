using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Application.UseCases.Task.Create;
using Task.Application.UseCases.Task.ViewAll;
using Task.Communication.Request;
using Task.Communication.Response;

namespace Tarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]RequestTaskJson request)
        {
            if (request.Name == null
                || request.Status == null
                || request.Status == null
                || request.Priority == null
                || request.Deadline == null
                || request.Description == null)
                return BadRequest();

            var response = new CreateTaskUseCase().Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewAllJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ViewAll()
        {
            var response = new ViewAllTasksUseCase().Excecute();

            if(response.Tasks.Any())
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof())]
    }
}
