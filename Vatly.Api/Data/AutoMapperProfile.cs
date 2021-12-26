using AutoMapper;
using Vatly.Api.Models;

namespace Vatly.Api.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<string[], Metar>()
            .ForMember(m => m.RawText, opts => opts.MapFrom(s => s[0]))
            .ForMember(m => m.Icao, opts => opts.MapFrom(s => s[1]))
            .ForMember(m => m.Date, opts => opts.MapFrom(s => s[2]))
            .ForMember(m => m.Temperature, opts => opts.MapFrom(s => s[5]))
            .ForMember(m => m.DewPoint, opts => opts.MapFrom(s => s[6]))
            .ForMember(m => m.WindDirection, opts => opts.MapFrom(s => s[7]))
            .ForMember(m => m.WindSpeed, opts => opts.MapFrom(s => s[8]))
            .ForMember(m => m.WindGust, opts => opts.MapFrom(s => s[9]))
            .ForMember(m => m.Visibility, opts => opts.MapFrom(s => s[10]))
            .ForMember(m => m.Pressure, opts => opts.MapFrom(s => s[11]));
    }
}