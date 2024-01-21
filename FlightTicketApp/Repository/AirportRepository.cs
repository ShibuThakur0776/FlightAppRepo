using FlightTicketApp.Repository.IRepository;

namespace FlightTicketApp.Repository
{
    public class AirportRepository:Repository<Models.Airport>,IAirportRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AirportRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
