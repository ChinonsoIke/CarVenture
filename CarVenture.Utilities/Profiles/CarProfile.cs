using AutoMapper;
using CarVenture.Dtos;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Utilities.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarRequestDto, Car>().ReverseMap();
            CreateMap<Car, CarResponseDto>().ReverseMap();
        }
    }
}
