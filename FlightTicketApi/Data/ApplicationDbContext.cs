using FlightTicketApi.Models;
using FlightTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightTicketApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
