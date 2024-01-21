using FlightTicketApp.Models;
using FlightTicketApp.Models.ViewModels;
using FlightTicketApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightTicketApp.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IFlightRepository _flightRepository;
        public AirportController(IAirportRepository airportRepository,IFlightRepository flightRepository)
        {
            _airportRepository = airportRepository;
            _flightRepository = flightRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region API
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _airportRepository.GetAllAsync(SD.AirportAPIPath) });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _airportRepository.DeleteAsync(SD.FlightAPIPath, id);
            if (status)
                return Json(new { success = true, message = "Data succesfully deleted !!!" });
            else
                return Json(new { success = false, message = "Data Deletion Unsuccesfully ,Failed !" });
        }
        #endregion
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<Flight> flights = await _flightRepository.GetAllAsync(SD.FlightAPIPath);
            AirportVM airportVM = new AirportVM()
            {
                Airport = new Airport(),
                flightList = flights.Select(f => new SelectListItem()
                {
                    Text = f.Name,
                    Value = f.Id.ToString()
                })
            };
            if(id==null) return View(airportVM);
            airportVM.Airport = await _airportRepository.GetAsync(SD.AirportAPIPath, id.GetValueOrDefault());
            if (airportVM.Airport == null) return NotFound();
            return View(airportVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AirportVM airportVM)
        {
            //if(ModelState.IsValid)
            //{
                if (airportVM.Airport.Id == 0)
                    await _airportRepository.CreateAsync(SD.AirportAPIPath, airportVM.Airport);
                else
                    await _airportRepository.UpdateAsync(SD.AirportAPIPath, airportVM.Airport);
                return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    IEnumerable<Flight> flights = await _flightRepository.GetAllAsync(SD.FlightAPIPath);
            //    airportVM = new AirportVM()
            //    {
            //        Airport = new Airport(),
            //        flightList = flights.Select(f => new SelectListItem()
            //        {
            //            Text = f.Name,
            //            Value = f.Id.ToString()
            //        })
            //    };
            //    return View(airportVM);
            //}
        }
    }
}
