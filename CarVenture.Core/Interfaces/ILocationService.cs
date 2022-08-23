using CarVenture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Interfaces
{
    public interface ILocationService : IService<LocationRequestDto, LocationResponseDto>
    {
    }
}
