namespace AspAirlinesWebApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public List<Airport>? Airports { get; set; }
        public List<Airline>? Airlines { get; set; }
    }
}
