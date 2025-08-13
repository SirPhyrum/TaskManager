using Task.Communication.Enums;

namespace Task.Application.Tasks
{
    public class RegTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateOnly Deadline { get; set; }
        public Status Status { get; set; }

        public RegTask(string name, string description, Priority priority, DateOnly deadline, Status status)
        {
            Name = name;
            Description = description;
            Priority = priority;
            Deadline = deadline;
            Status = status;
        }
    }
}
