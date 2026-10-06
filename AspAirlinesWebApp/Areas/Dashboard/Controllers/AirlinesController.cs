using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspAirlinesWebApp.Models;
using AspAirlinesWebApp.Areas.Dashboard.Models;

[Area("Dashboard")]
public class AirlinesController : Controller
{
    private readonly FlightsDbContext _context;
    private readonly DashboardDbContext _dashboardContext;

    string imagesDir = $"{Directory.GetCurrentDirectory()}\\wwwroot\\images";

    public AirlinesController()
    {
        _context = new FlightsDbContext();
        _dashboardContext = new DashboardDbContext();
    }

    // GET: AIRLINES
    public async Task<IActionResult> Index()    
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        ViewData["ImagesDir"] = imagesDir;

        return View(await _context.Airlines
                                  .Include(a => a.City)
                                  .ToListAsync());
    }

    // GET: AIRLINES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var airline = await _context.Airlines
            .FirstOrDefaultAsync(m => m.Id == id);
        if (airline == null)
        {
            return NotFound();
        }

        return View(airline);
    }

    // GET: AIRLINES/Create
    public IActionResult Create()
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        ViewData["Cities"] = _context.Cities.ToList();
        return View();
    }

    // POST: AIRLINES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,City,CityId,Logo,Flights")] Airline airline)
    {
        if (ModelState.IsValid)
        {
            var logo = Request.Form.Files[0];

            using FileStream file = new($"{imagesDir}\\{logo.FileName}", FileMode.Create);
            logo.CopyToAsync(file);

            airline.Logo = logo.FileName;

            _context.Add(airline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(airline);
    }

    // GET: AIRLINES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        ViewData["Items"] = _dashboardContext.Items.ToList();
        ViewData["Cities"] = _context.Cities.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var airline = await _context.Airlines.FindAsync(id);
        if (airline == null)
        {
            return NotFound();
        }
        return View(airline);
    }

    // POST: AIRLINES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,City,Logo,Flights")] Airline airline)
    {
        if (id != airline.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(airline);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(airline.Id))
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
        return View(airline);
    }

    // GET: AIRLINES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var airline = await _context.Airlines
            .FirstOrDefaultAsync(m => m.Id == id);
        if (airline == null)
        {
            return NotFound();
        }

        return View(airline);
    }

    // POST: AIRLINES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var airline = await _context.Airlines.FindAsync(id);
        if (airline != null)
        {
            _context.Airlines.Remove(airline);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AirlineExists(int? id)
    {
        return _context.Airlines.Any(e => e.Id == id);
    }
}
