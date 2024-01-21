using Microsoft.AspNetCore.Mvc;

namespace FlightTicketApp
{
    public class SD
    {
        public static string APIBaseUrl = "https://localhost:44350/";
        public static string FlightAPIPath = APIBaseUrl + "api/Flight/";
        public static string AirportAPIPath = APIBaseUrl + "api/Airport/";
    }
}
