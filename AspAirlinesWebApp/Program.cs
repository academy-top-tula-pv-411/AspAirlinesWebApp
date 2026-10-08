using AspAirlinesWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//var connectionString = builder.Configuration.GetConnectionString("FlightsDbContext") ?? throw new InvalidOperationException("Connection string 'FlightsDbContext' not found.");
//builder.Services.AddDbContext<FlightsDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAntiforgery();

app.MapControllerRoute(
    name: "Dashboard",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
