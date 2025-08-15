using Task.Application.Tasks;
using Task.Communication.Request;
using Task.Communication.Response;

namespace Task.Application.UseCases.Task.Edit
{
    public class EditUseCase
    {
        public static void Execute(int id, RequestTaskJson request)
        {
            RegTask task = TaskList.Tasks.FirstOrDefault(x => x.Id == id);

            if (task.Name != null)
                task.Name = request.Name;
            if (task.Description != null)
                task.Description = request.Description;
            if (task.Priority != null)
                task.Priority = request.Priority;
            if (task.Deadline != null)
                task.Deadline = request.Deadline;
            if (task.Status != null) 
                task.Status = request.Status;           
        }
    }
}
