using System.ComponentModel.DataAnnotations.Schema;

namespace AspAirlinesWebApp.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public City? City { get; set; }
        public int CityId { get; set; }
        public string? Logo { get; set; }

        public List<Flight>? Flights { get; set; }
    }
}
