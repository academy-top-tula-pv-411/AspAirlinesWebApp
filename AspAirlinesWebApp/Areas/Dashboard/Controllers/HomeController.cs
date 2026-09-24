using AspAirlinesWebApp.Areas.Dashboard.Models;
using AspAirlinesWebApp.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspAirlinesWebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DashboardViewModel viewModel = new();

            using(DashboardDbContext context = new())
            {
                viewModel.Items = context.Items.ToList();
            }

            return View(viewModel);
        }
    }
}
