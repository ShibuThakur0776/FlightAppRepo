using FlightTicketApp.Models;

namespace FlightTicketApp.Data.Repository.IRepository
{
    public interface IAirportRepository
    {
        ICollection<Airport> GetAirports();
        ICollection<Airport> GetFlightsInAirport(int flightId);
        Airport GetAirport(int airportId);
        bool AirportExists(string airportName);
        bool AirportExists(int airportId);
        bool CreateAirport(Airport airport);
        bool UpdateAirport(Airport airport);
        bool DeleteAirport(Airport airport);
        bool Save();
    }
}
