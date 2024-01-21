using FlightTicketApp.Data.Repository.IRepository;
using FlightTicketApp.Models;

namespace FlightTicketApp.Data.Repository
{
    public class FlightRepository:IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateFlights(Flight flight)
        {
            _context.Flights.Add(flight);
            return Save();
        }

        public bool DeleteFlights(Flight flight)
        {
            _context.Flights.Remove(flight);
            return Save();
        }

        public bool FlightExists(int FlightId)
        {
            return _context.Flights.Any(f => f.Id == FlightId);
        }

        public bool FlightExists(string FlightName)
        {
            return _context.Flights.Any(f => f.Name == FlightName);
        }
        public Flight GetFlight(int FlightId)
        {
            return _context.Flights.FirstOrDefault(f => f.Id == FlightId);
        }
        public Flight GetFlightById(int FlightId)
        {
            return _context.Flights.Find(FlightId);
        }

        public ICollection<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges()==1? true:false;
        }

        public bool UpdateFlights(Flight flight)
        {
            _context.Flights.Update(flight);
            return Save();
        }
    }
}
