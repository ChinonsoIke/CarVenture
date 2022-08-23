using AutoMapper;
using CarVenture.Dtos;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Utilities.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderRequestDto, Order>().ReverseMap();
            CreateMap<Order, OrderResponseDto>().ReverseMap();
        }
    }
}
