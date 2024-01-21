using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightTicketApp.Models.ViewModels
{
    public class AirportVM
    {
        public Airport Airport { get; set; }
        public IEnumerable<SelectListItem> flightList { get; set; }

    }
}
