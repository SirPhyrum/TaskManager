using Task.Application.Tasks;
using Task.Communication.Response;

namespace Task.Application.UseCases.Task.ViewTask
{
    public class ViewTaskUseCase
    {
        public ResponseViewTaskJson Execute (int id)
        {
            RegTask task = TaskList.Tasks.FirstOrDefault(x => x.Id == id);

            var response = new ResponseViewTaskJson(task.Id, task.Name, task.Description, task.Priority, task.Deadline, task.Status);

            return response;
        } 
    }
}
