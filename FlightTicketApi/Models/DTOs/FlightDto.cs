using System.ComponentModel.DataAnnotations;
using static FlightTicketApp.Models.Flight;

namespace FlightTicketApp.Models.DTOs
{
    public class FlightDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public int Model { get; set; }
        [Display(Name = "Airline")]
        public Airline Airline_Name { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime Departure_Time { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime Arrival_Time { get; set; }
        [Display(Name = "Departure State")]
        public string Departure_State { get; set; }
        [Display(Name = "Arrival State")]
        public string Arrival_State { get; set; }

    }
}
