using System.ComponentModel.DataAnnotations;

namespace FlightTicketApp.Models
{
    public class Airport
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public enum AirportType { International, Domestic, Private }
        public AirportType Airport_Type { get; set; }
        public string State { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
