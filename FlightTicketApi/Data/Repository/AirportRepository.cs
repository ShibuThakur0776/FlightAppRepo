using FlightTicketApp.Data.Repository.IRepository;
using FlightTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightTicketApp.Data.Repository
{
    public class AirportRepository:IAirportRepository
    {
        private readonly ApplicationDbContext _context;
        public AirportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AirportExists(string airportName)
        {
            return _context.Airports.Any(a => a.Name == airportName);
        }

        public bool AirportExists(int airportId)
        {
            return _context.Airports.Any(a => a.Id == airportId);
        }

        public bool CreateAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            return Save();
        }

        public bool DeleteAirport(Airport airport)
        {
            _context.Airports.Remove(airport);
            return Save();
        }

        public Airport GetAirport(int airportId)
        {
            return _context.Airports.Find(airportId);
        }

        public ICollection<Airport> GetAirports()
        {
            return _context.Airports.Include(a=>a.Flight).ToList();
        }

        public ICollection<Airport> GetFlightsInAirport(int flightId)
        {
            return _context.Airports.Include(a => a.FlightId).Where(a =>a.FlightId == flightId).ToList(); 
        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true: false;
        }

        public bool UpdateAirport(Airport airport)
        {
            _context.Airports.Update(airport);
            return Save();
        }
    }
}
