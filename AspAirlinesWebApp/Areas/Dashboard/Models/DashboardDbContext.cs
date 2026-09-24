using Microsoft.EntityFrameworkCore;

namespace AspAirlinesWebApp.Areas.Dashboard.Models
{
    public class DashboardDbContext : DbContext
    {
        public DbSet<EntityItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DashboardConnection"));
        }
    }
}
