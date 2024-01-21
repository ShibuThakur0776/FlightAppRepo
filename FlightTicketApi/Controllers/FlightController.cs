using AutoMapper;
using FlightTicketApp.Data.Repository.IRepository;
using FlightTicketApp.Models;
using FlightTicketApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public FlightController(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }
        [HttpGet(Name ="GetAllFlights")]
        public IActionResult GetFlights() 
        {
            var flightListDto = _flightRepository.GetFlights().ToList().Select(_mapper.Map<Flight,FlightDto>);
            return Ok(flightListDto);
        }
        [HttpGet("{flightId:int}",Name ="GetFlight")]
        public IActionResult GetFlight(int flightId)
        {
            var flight = _flightRepository.GetFlight(flightId);
            if(flight == null) return NotFound();
            var flightDto = _mapper.Map<Flight, FlightDto>(flight);
            return Ok(flightDto);

        }
        [HttpPost(Name ="CreateFlight")]
        public IActionResult CreateFlight([FromBody]FlightDto flightDto)
        {
            if(flightDto == null) return BadRequest(ModelState);
            if (_flightRepository.FlightExists(flightDto.Name))
            {
                ModelState.AddModelError("", "Flight already exists in DB");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }if(!ModelState.IsValid) return BadRequest(ModelState);

            var flight = _mapper.Map<FlightDto,Flight>(flightDto);

            if (!_flightRepository.CreateFlights(flight))
            {
                ModelState.AddModelError("",$"Something went wrong while save data: { flight.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //return Ok(flight);
            return CreatedAtRoute("GetFlight",new {flightId = flight.Id},flight);//201
        }
        [HttpPut]
        public IActionResult UpdateFlight([FromBody]FlightDto flightDto)
        {
            if(flightDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var flight = _mapper.Map<FlightDto, Flight>(flightDto);
            if (!_flightRepository.UpdateFlights(flight))
            {
                ModelState.AddModelError("", $"Something went wrong while update data :{flight.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();//204
        }
        [HttpDelete("{flightId:int}")]
        public IActionResult DeleteFlight(int flightId)
        {
            if (!_flightRepository.FlightExists(flightId))
            {
                return NotFound();
            }
            var flight = _flightRepository.GetFlight(flightId);
            if(flight == null) return NotFound();
            if(!_flightRepository.DeleteFlights(flight))
            {
                ModelState.AddModelError("", $"Something went wrong while delete data : {flight.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
            
        }
        
    }
}
