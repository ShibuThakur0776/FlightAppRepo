using System.ComponentModel.DataAnnotations.Schema;

namespace FlightTicketApp.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public enum AirportType { International,Domestic,Private}
        public AirportType Airport_Type {  get; set; }
        public string State { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}
