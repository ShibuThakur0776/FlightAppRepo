using Microsoft.AspNetCore.Mvc;

namespace FlightTicketApp.Models.ViewModels
{
    public class IndexVM 
    {
        public IEnumerable<Flight> FlightList { get; set; }
        public IEnumerable<Airport> AirportList { get; set; }
    }
}
