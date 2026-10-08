namespace AspAirlinesWebApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public DateOnly DateFlight { get; set; }
        public TimeOnly TimeFlight { get; set; }

        public Airline? Airline { get; set; }
        public int? AirlineId { get; set; }
        
        public Airport? Departure { get; set; }
        public int? DepartureId { get; set; }
        
        public Airport? Arrival { get; set; }
        public int? ArrivalId { get; set; }
    }
}
