namespace Task.Communication.Response
{
    public class ResponseCreateJson
    {
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;

        public ResponseCreateJson(int id, string name)
        {
            Id = id;
            this.name = name;
        }
    }
}
