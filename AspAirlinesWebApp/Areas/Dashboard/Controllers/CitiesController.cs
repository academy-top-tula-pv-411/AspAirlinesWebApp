
using AspAirlinesWebApp.Areas.Dashboard.Models;
using AspAirlinesWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("Dashboard")]
public class CitiesController : Controller
{
    FlightsDbContext flightsContext = new();
    DashboardDbContext dashboardContext = new();

    public CitiesController()
    {
        
    }

    // GET: CITYS
    public async Task<IActionResult> Index()    
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        return View("Index", await flightsContext.Cities.ToListAsync());
    }

    // GET: CITYS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var city = await flightsContext.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    //// GET: CITYS/Create
    public IActionResult Create()
    {
        ViewData["Items"] = dashboardContext.Items.ToList();
        return View();
    }

    // POST: CITYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title")] City city)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        if (ModelState.IsValid)
        {
            flightsContext.Add(city);
            await flightsContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(city);
    }

    // GET: CITYS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var city = await flightsContext.Cities.FindAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return View(city);
    }

    // POST: CITYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title")] City city)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        if (id != city.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                flightsContext.Update(city);
                await flightsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.Id))
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
        return View(city);
    }

    // GET: CITYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        if (id == null)
        {
            return NotFound();
        }

        var city = await flightsContext.Cities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // POST: CITYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        ViewData["Items"] = dashboardContext.Items.ToList();

        var city = await flightsContext.Cities.FindAsync(id);
        if (city != null)
        {
            flightsContext.Cities.Remove(city);
        }

        await flightsContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CityExists(int? id)
    {
        return flightsContext.Cities.Any(e => e.Id == id);
    }
}
