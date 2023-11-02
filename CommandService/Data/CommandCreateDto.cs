namespace CommandService.Data
{
    public class CommandCreateDto
    {
        public string HowTo { get; set; }

        public string CommandText { get; set; }

        public int PlatformId { get; set; }
    }
}