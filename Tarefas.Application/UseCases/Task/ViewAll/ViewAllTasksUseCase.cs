using Task.Application.Tasks;
using Task.Communication.Response;

namespace Task.Application.UseCases.Task.ViewAll
{
    public class ViewAllTasksUseCase
    {
        public ResponseViewAllJson Excecute()
        { 
            ResponseViewAllJson response = new ResponseViewAllJson();

            foreach(RegTask task in TaskList.Tasks)
            {
                ResponseShortTaskJson shortTask = new ResponseShortTaskJson();
                shortTask.Id = task.Id;
                shortTask.Name = task.Name;
                shortTask.Status = task.Status;
                shortTask.Priority = task.Priority;

                response.Tasks.Add(shortTask);
            }

            return response;
        }
    }
}
