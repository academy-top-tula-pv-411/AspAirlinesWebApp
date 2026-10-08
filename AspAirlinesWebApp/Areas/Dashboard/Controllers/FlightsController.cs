
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspAirlinesWebApp.Models;
using AspAirlinesWebApp.Areas.Dashboard.Models;

[Area("Dashboard")]
public class FlightsController : Controller
{
    private readonly FlightsDbContext _context;
    private readonly DashboardDbContext _dashboardContext;

    public FlightsController()
    {
        _context = new();
        _dashboardContext = new();
    }

    // GET: FLIGHTS
    public async Task<IActionResult> Index()    
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        return View(await _context.Flights
                                  .Include(f => f.Airline)
                                  .Include(f => f.Departure)
                                  .Include(f => f.Arrival)
                                  .ToListAsync());
    }

    // GET: FLIGHTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
                                   .Include(f => f.Airline)
                                   .Include(f => f.Departure)
                                   .Include(f => f.Arrival)
                                   .FirstOrDefaultAsync(m => m.Id == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // GET: FLIGHTS/Create
    public IActionResult Create()
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        ViewData["Airports"] = _context.Airports.ToList();
        ViewData["Airlines"] = _context.Airlines.ToList();

        return View();
    }

    // POST: FLIGHTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,DateFlight,TimeFlight,Airline,Departure,Arrival,AirlineId,DepartureId,ArrivalId")] Flight flight)
    {
        if (ModelState.IsValid)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: FLIGHTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        ViewData["Airports"] = _context.Airports.ToList();
        ViewData["Airlines"] = _context.Airlines.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
                                   .Include(f => f.Airline)
                                   .Include(f => f.Departure)
                                   .Include(f => f.Arrival)
                                   .FirstOrDefaultAsync(m => m.Id == id);
        if (flight == null)
        {
            return NotFound();
        }
        return View(flight);
    }

    // POST: FLIGHTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,DateFlight,TimeFlight,Airline,Departure,Arrival,AirlineId,DepartureId,ArrivalId")] Flight flight)
    {
        if (id != flight.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(flight);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(flight.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: FLIGHTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.Flights
                                   .Include(f => f.Airline)
                                   .Include(f => f.Departure)
                                   .Include(f => f.Arrival)
                                   .FirstOrDefaultAsync(m => m.Id == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // POST: FLIGHTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FlightExists(int? id)
    {
        return _context.Flights.Any(e => e.Id == id);
    }
}

