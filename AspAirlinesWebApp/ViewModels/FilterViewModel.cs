using AspAirlinesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspAirlinesWebApp.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Airlines { get; set; }
        public SelectList Airports { get; set; }
        public int SelectedAirline { get; set; }
        public int SelectedAirport { get; set; }

        public FilterViewModel(List<Airline> airlines,
                               int selectedAirline,
                               List<Airport> airports,
                               int selectedAirport)
        {
            airlines.Insert(0, new Airline() { Id = 0, Title = "All Airlines" });
            airports.Insert(0, new Airport() { Id = 0, Title = "All Airports" });

            Airlines = new SelectList(airlines, "Id", "Title", selectedAirline);
            Airports = new SelectList(airports, "Id", "Title", selectedAirport);
            SelectedAirline = selectedAirline;
            SelectedAirport = selectedAirport;
        }
    }
}

