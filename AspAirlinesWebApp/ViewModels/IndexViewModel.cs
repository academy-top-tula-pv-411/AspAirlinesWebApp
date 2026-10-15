using AspAirlinesWebApp.Models;

namespace AspAirlinesWebApp.ViewModels
{
    public class IndexViewModel
    {
        public List<Flight> Flights { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public IndexViewModel(List<Flight> flights, 
            SortViewModel sortViewModel,
            FilterViewModel filterViewModel,
            PageViewModel pageViewModel)
        {
            Flights = flights;
            SortViewModel = sortViewModel;
            FilterViewModel = filterViewModel;
            PageViewModel = pageViewModel;
        }

    }
}
