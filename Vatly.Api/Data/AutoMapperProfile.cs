using AutoMapper;
using Vatly.Api.Models;
using Vatly.Api.Models.Responses;

namespace Vatly.Api.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<VatsimFlightPlan, FlightPlan>()
            .ForMember(d => d.DepartureTime, opt => opt.MapFrom(src => src.Deptime))
            .ForMember(d => d.Rules, opt => opt.MapFrom(src => src.FlightRules))
            .ForMember(d => d.Speed, opt => opt.MapFrom(src => src.CruiseTas))
            .ForMember(d => d.Destination, opt => opt.MapFrom(src => src.Departure))
            .ForMember(d => d.Origin, opt => opt.MapFrom(src => src.Arrival))
            .ForMember(d => d.Aircraft, opt => opt.MapFrom(src => src.AircraftShort));

        CreateMap<VatsimFlight, Flight>();
    }
}