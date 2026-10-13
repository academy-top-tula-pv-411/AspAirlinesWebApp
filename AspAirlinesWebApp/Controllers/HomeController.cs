using AspAirlinesWebApp.Models;
using AspAirlinesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AspAirlinesWebApp.Controllers
{
    public class HomeController : Controller
    {
        FlightsDbContext _flightsDbContext = new FlightsDbContext();
        public async Task<IActionResult> Index(PropertySort propertySort = PropertySort.Airline,
                                                bool directionSort = true)
        {
            ViewBag.MenuMain = new List<string>() { "Home", "About", "Gallery", "Contacts" };

            IQueryable<Flight> flights = _flightsDbContext.Flights
                                           .Include(f => f.Departure)
                                            .ThenInclude(d => d.City)
                                           .Include(f => f.Arrival)
                                            .ThenInclude(a => a.City)
                                           .Include(f => f.Airline);



            flights = propertySort switch
            {
                PropertySort.Airline => (directionSort) ? flights.OrderBy(f => f.Airline!.Title)
                                                        : flights.OrderByDescending(f => f.Airline!.Title),
                PropertySort.Departure => (directionSort) ? flights.OrderBy(f => f.Departure!.Title)
                                                    : flights.OrderByDescending(f => f.Departure!.Title),
                PropertySort.Arrival => (directionSort) ? flights.OrderBy(f => f.Arrival!.Title)
                                                : flights.OrderByDescending(f => f.Arrival!.Title),
                PropertySort.Date => (directionSort) ? flights.OrderBy(f => f.DateFlight)
                                            : flights.OrderByDescending(f => f.DateFlight),
                _ => throw new NotImplementedException()
            };

            IndexViewModel viewModel = new()
            {
                Flights = flights.ToList(),
                SortViewModel = new(
                    propertySort,
                    directionSort
                )
            };

            return View(viewModel);
        }

        
    }
}
