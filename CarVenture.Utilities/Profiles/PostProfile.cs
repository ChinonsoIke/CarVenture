using AutoMapper;
using CarVenture.Dtos;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Utilities.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostRequestDto, Post>().ReverseMap();
            CreateMap<Post, PostResponseDto>().ReverseMap();
        }
    }
}
