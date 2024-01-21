using FlightTicketApp.Models;
using FlightTicketApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FlightTicketApp.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _flightRepository.GetAllAsync(SD.FlightAPIPath) });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) { 
            var status = await _flightRepository.DeleteAsync(SD.FlightAPIPath,id);
            if (status)
            {
                return Json(new { success = true, message = "data deleted sucess" });
            }
            else
            {
                return Json(new { success = false, message = "error while delete data" });
            }
        }
        #endregion
       public async Task<IActionResult> Upsert(int? id)
        {
            Flight flight = new Flight();
            if(id == null) return View(flight);
            flight = await _flightRepository.GetAsync(SD.FlightAPIPath, id.GetValueOrDefault());
            if (flight == null) return NotFound();
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Flight flight)
        {
            if(ModelState.IsValid)
            {
                //Getting photo from file if selected
                var files = HttpContext.Request.Form.Files;
                //Create picture into byte code
                if(files.Count > 0)
                {
                    //byte[] p1 = null;
                    //using(var fs1 = files[0].OpenReadStream)
                    //{
                    //    using(var ms1 = new MemoryStream())
                    //    {
                    //        fs1.CopyTo(ms1);
                    //        p1 = ms1.ToArray();
                    //    }
                    //}
                    //flight.Picture = p1;
                }
                else
                {
                    var flightInDB = await _flightRepository.GetAsync(SD.FlightAPIPath,flight.Id);
                    flight.Picture = flightInDB.Picture;
                }
                if(flight.Id == 0)
                {
                    await _flightRepository.CreateAsync(SD.FlightAPIPath, flight);
                }
                else
                {
                    await _flightRepository.UpdateAsync(SD.FlightAPIPath, flight);
                }
                return RedirectToAction(nameof(Index));
            }
           return View(flight);
        }
    }
}
