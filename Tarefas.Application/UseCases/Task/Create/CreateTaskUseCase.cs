using Task.Application.Tasks;
using Task.Communication.Request;
using Task.Communication.Response;

namespace Task.Application.UseCases.Task.Create
{
    public class CreateTaskUseCase
    {
        public ResponseCreateJson Execute(RequestTaskJson request)
        {
            RegTask rt = new RegTask(request.Name, request.Description, request.Priority, request.Deadline, request.Status);

            if (TaskList.Tasks.Count == 0)
                rt.Id = 1;
            else
            {
                rt.Id = TaskList.Tasks.Max(i => i.Id) + 1;
            }

            TaskList.Tasks.Add(rt);

            ResponseCreateJson response = new ResponseCreateJson(rt.Id, rt.Name);

            return response;
        }
    }
}
