using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlightTicketApp.Models.Airport;

namespace FlightTicketApp.Models.DTOs
{
    public class AirportDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public AirportType Airport_Type { get; set; }
        public string State { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
