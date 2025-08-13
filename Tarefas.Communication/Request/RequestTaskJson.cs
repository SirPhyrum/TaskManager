using Task.Communication.Enums;

namespace Task.Communication.Request
{
    public class RequestTaskJson
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateOnly Deadline { get; set; }
        public Status Status { get; set; }

        public RequestTaskJson(string name, string description, Priority priority, DateOnly deadline, Status status)
        {
            Name = name;
            Description = description;
            Priority = priority;
            Deadline = deadline;
            Status = status;
        }
    }
}
