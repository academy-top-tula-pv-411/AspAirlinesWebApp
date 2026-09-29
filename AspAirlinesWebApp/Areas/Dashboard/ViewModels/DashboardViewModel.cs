using AspAirlinesWebApp.Areas.Dashboard.Models;

namespace AspAirlinesWebApp.Areas.Dashboard.ViewModels
{
    public class DashboardViewModel
    {
        public List<EntityItem> Items { get; set; } = new();
        public CitiesViewModel CitiesViewModel { get; set; } = new();
    }
}
