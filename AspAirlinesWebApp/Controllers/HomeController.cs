using AspAirlinesWebApp.Models;
using AspAirlinesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AspAirlinesWebApp.Controllers
{
    public class HomeController : Controller
    {
        FlightsDbContext _flightsDbContext = new FlightsDbContext();
        public async Task<IActionResult> Index(int page = 1, int pageSize = 3, int airline = 0, int airport = 0, SortState sortState = SortState.AirlineAsc)
        {
            ViewBag.MenuMain = new List<string>() { "Home", "About", "Gallery", "Contacts" };

            IQueryable<Flight> flights = _flightsDbContext.Flights
                                           .Include(f => f.Departure)
                                            .ThenInclude(d => d.City)
                                           .Include(f => f.Arrival)
                                            .ThenInclude(a => a.City)
                                           .Include(f => f.Airline);

            if(airline != 0)
                flights = flights.Where(f => f.AirlineId == airline);
            if(airport != 0)
                flights = flights.Where(f => f.DepartureId == airport 
                                             || f.ArrivalId == airport);

            flights = sortState switch
            {
                SortState.AirlineAsc => flights.OrderBy(f => f.Airline!.Title),
                SortState.AirlineDesc => flights.OrderByDescending(f => f.Airline!.Title),
                SortState.DepartureAsc => flights.OrderBy(f => f.Departure!.Title),
                SortState.DepartureDesc => flights.OrderByDescending(f => f.Departure!.Title),
                SortState.ArrivalAsc => flights.OrderBy(f => f.Arrival!.Title),
                SortState.ArrivalDesc => flights.OrderByDescending(f => f.Arrival!.Title),
                SortState.DateAsc => flights.OrderBy(f => f.DateFlight),
                SortState.DateDesc => flights.OrderByDescending(f => f.DateFlight),
                _ => throw new NotImplementedException()
            };

            int flightsCount = flights.Count();

            flights = flights.Skip((page - 1) * pageSize)
                             .Take(pageSize);

            IndexViewModel viewModel = new(
                flights.ToList(),
                new SortViewModel(sortState),
                new FilterViewModel(
                    _flightsDbContext.Airlines.ToList(), airline,
                    _flightsDbContext.Airports.ToList(), airport
                    ),
                new PageViewModel(page, pageSize, flightsCount));

            return View(viewModel);
        }

        
    }
}
