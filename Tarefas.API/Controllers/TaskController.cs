using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Tasks;
using Task.Application.UseCases.Task.Create;
using Task.Application.UseCases.Task.Delete;
using Task.Application.UseCases.Task.Edit;
using Task.Application.UseCases.Task.ViewAll;
using Task.Application.UseCases.Task.ViewTask;
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
        [ProducesResponseType(typeof(ResponseViewAllJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult View([FromRoute]int id)
        {
            if(!TaskList.Tasks.Any(p => p.Id == id))
                return NotFound();

            var response = new ViewTaskUseCase().Execute(id);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult Edit([FromRoute] int id, [FromBody] RequestTaskJson request)
        {
            if (!TaskList.Tasks.Any(p => p.Id == id))
                return NotFound();

            EditUseCase.Execute(id,request);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!TaskList.Tasks.Any(p => p.Id == id))
                return NotFound();

            DeleteUseCase.Execute(id);

            return NoContent();
        }
    }
}
