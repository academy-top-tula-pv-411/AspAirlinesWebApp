using Microsoft.EntityFrameworkCore;

namespace AspAirlinesWebApp.Models
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                        .HasOne(a => a.City)
                        .WithMany(a => a.Airports)
                        .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<Airline>()
                        .HasOne(a => a.City)
                        .WithMany(c => c.Airlines)
                        .HasForeignKey(a => a.CityId);


            modelBuilder.Entity<Flight>()
                        .Property(f => f.DateFlight)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Flight>()
                        .Property(f => f.TimeFlight)
                        .HasDefaultValueSql("GETDATE()");
        }
    }
}
