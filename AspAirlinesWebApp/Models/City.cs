using System.ComponentModel.DataAnnotations;

namespace AspAirlinesWebApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City's Title is required")]
        public string Title { get; set; } = null!;

        public List<Airport>? Airports { get; set; }
        public List<Airline>? Airlines { get; set; }
    }
}
