using AspAirlinesWebApp.Models;

namespace AspAirlinesWebApp.ViewModels
{
    public class IndexViewModel
    {
        public List<Flight> Flights { get; set; }
        public SortViewModel SortViewModel { get; set; }

    }
}
