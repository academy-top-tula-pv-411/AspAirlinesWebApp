namespace AspAirlinesWebApp.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public City? City { get; set; }

        public List<Flight>? Flights { get; set; }

    }
}
