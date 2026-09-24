namespace AspAirlinesWebApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Airline? Airline { get; set; }
        public Airport? Departure { get; set; }
        public Airport? Arrival { get; set; }
    }
}
