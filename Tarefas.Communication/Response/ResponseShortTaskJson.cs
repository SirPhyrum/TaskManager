using Task.Communication.Enums;

namespace Task.Communication.Response
{
    public class ResponseShortTaskJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public Status Status { get; set; }

    }
}
