using FlightTicketApp.Models;

namespace FlightTicketApp.Data.Repository.IRepository
{
    public interface IFlightRepository
    {
        ICollection<Flight> GetFlights();
        Flight GetFlightById(int FlightId);
        bool FlightExists(int FlightId);
        bool FlightExists(String FlightName);
        bool CreateFlights(Flight flight);
        bool UpdateFlights(Flight flight);
        bool DeleteFlights(Flight flight);
        bool Save();
        Flight GetFlight(int flightId);
    }
}
