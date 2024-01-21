using AutoMapper;
using FlightTicketApp.Data.Repository.IRepository;
using FlightTicketApp.Models;
using FlightTicketApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : Controller
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        public AirportController(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }
        [HttpGet(Name ="GetAirports")]
        public IActionResult GetAirports()
        {
            return Ok(_airportRepository.GetAirports().ToList()
                .Select(_mapper.Map<Airport,AirportDto>));
        }
        [HttpGet("{airportId:int}",Name ="GetAirport")]
        public IActionResult GetAirport(int airportId)
        {
            var airport = _airportRepository.GetAirport(airportId);
            if(airport == null) return NotFound();
            return Ok(_mapper.Map<AirportDto>(airport));
        }
        [HttpPost]
        public IActionResult CreateAirport([FromBody] AirportDto airportDto)
        {
            if (airportDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest();
            if(_airportRepository.AirportExists(airportDto.Name))
            {
                ModelState.AddModelError("",$"Airport already in DB :{airportDto.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var airport = _mapper.Map<Airport>(airportDto);
            if (!_airportRepository.CreateAirport(airport))
            {
                ModelState.AddModelError("", $"Something went wrong while save airport : {airport.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("GetAirport",new {airportId =airport.Id},airport);
        }
        [HttpPut]
        public IActionResult UpdateAirport([FromBody] AirportDto airportDto)
        {
            if (airportDto == null) return BadRequest(ModelState);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var airport = _mapper.Map<Airport>(airportDto);
            if (!_airportRepository.UpdateAirport(airport))
            {
                ModelState.AddModelError("", $"Something went wrong while update airport : {airport.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError) ;
            }
            return NoContent();
        }
        [HttpDelete("{airportId:int}")]
        public IActionResult DeleteAirport(int airportId)
        {
            if (!_airportRepository.AirportExists(airportId)) return NotFound();
            var airportInDB = _airportRepository.GetAirport(airportId);
            if (airportInDB == null) return NotFound();
            if (!_airportRepository.DeleteAirport(airportInDB))
            {
                ModelState.AddModelError("",$"Something went wrong while delete airport : {airportInDB.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
