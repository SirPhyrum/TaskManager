using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Application.UseCases.Task.Create;
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
        public IActionResult Create([FromBody]RequestTaskJson request)
        {
            var response = new CreateTaskUseCase().Execute(request);

            return Created(string.Empty, response);
        }


    }
}
