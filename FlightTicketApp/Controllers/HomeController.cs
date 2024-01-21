using FlightTicketApp.Models;
using FlightTicketApp.Models.ViewModels;
using FlightTicketApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightTicketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightRepository _flightRepository;
        private readonly IAirportRepository _airportRepository;

        public HomeController(ILogger<HomeController> logger, 
            IAirportRepository airportRepository,IFlightRepository flightRepository)
        {
            _logger = logger;
            _airportRepository = airportRepository; 
            _flightRepository = flightRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IndexVM indexVM = new IndexVM()
            {
                FlightList = await _flightRepository.GetAllAsync(SD.FlightAPIPath),
                AirportList = await _airportRepository.GetAllAsync(SD.AirportAPIPath)
            };
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
