using AutoMapper;
using CarVenture.Dtos;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Utilities.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationRequestDto, Location>().ReverseMap();
            CreateMap<Location, LocationResponseDto>().ReverseMap();
        }
    }
}
