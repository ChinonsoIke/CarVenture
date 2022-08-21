using AutoMapper;
using CarVenture.Dtos;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Utilities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDto, User>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
        }
    }
}
