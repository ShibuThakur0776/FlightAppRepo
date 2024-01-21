using System.ComponentModel.DataAnnotations;

namespace FlightTicketApp.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  
        public byte[] Picture { get; set; }
        [Required]
        public int Price { get; set; }
        public int Model { get; set; }
        public enum Airline { Indigo, AirIndia, Vistara, Emirates}
        [Display(Name="Airline")]
        public Airline Airline_Name { get; set; }
        [Display(Name="Departure Time")]
        public DateTime Departure_Time { get; set; }
        [Display(Name="Arrival Time")]
        public DateTime Arrival_Time { get; set; }
        [Display(Name="Departure State")]
        public string Departure_State { get; set; }
        [Required]
        [Display(Name="Arrival State")]
        public string Arrival_State { get; set; }
    }
}
