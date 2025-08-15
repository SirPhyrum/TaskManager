namespace Task.Application.UseCases.Task.Delete
{
    public class DeleteUseCase
    {
        public static void Execute(int id)
        {
            Tasks.TaskList.Tasks.RemoveAll(x => x.Id == id);
        }
    }
}
