using CarVenture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Interfaces
{
    public interface ICarService : IService<CarRequestDto, CarResponseDto>
    {
        /// <summary>
        /// Gets all Car objetcs that have a matching LocationId property
        /// </summary>
        /// <param name="locationId">string location ID</param>
        /// <returns>A list of CarResponseDto objects</returns>
        public List<CarResponseDto> GetAll(string locationId);
    }
}
