using AutoMapper;
using FlightTicketApp.Models;
using FlightTicketApp.Models.DTOs;

namespace FlightTicketApp.Data.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<FlightDto, Flight>().ReverseMap();
            CreateMap<AirportDto, Airport>().ReverseMap();
        }
    }
}

//db -model -rep -dto -controller //read
// controller - dto - rep -model -db //create upd del
//db --model -dto
//dto --model -db

