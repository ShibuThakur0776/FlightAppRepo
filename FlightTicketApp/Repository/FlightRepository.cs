using FlightTicketApp.Repository.IRepository;

namespace FlightTicketApp.Repository
{
    public class FlightRepository:Repository<Models.Flight>,IFlightRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FlightRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory) 
        {

            _httpClientFactory = httpClientFactory;

        }
    }
}
