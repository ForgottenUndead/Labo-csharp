namespace EventPlanner.Models
{
    public class ToCreateEvent
    {
        public long Id { get; set; }
        public string? NomEvent { get; set; }
        public DateTime EventTime { get; set; }
        public bool IsComplete { get; set; }
    }
}
