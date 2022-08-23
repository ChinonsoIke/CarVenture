using AutoMapper;
using CarVenture.Core.Interfaces;
using CarVenture.Data.Interfaces;
using CarVenture.Dtos;
using CarVenture.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;
        private readonly ILogger _logger;

        public LocationService(IMapper mapper, ILocationRepository repository, ILogger<LocationService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task AddAsync(LocationRequestDto locationRequestDto)
        {
            var location = _mapper.Map<Location>(locationRequestDto);

            if (location == null)
            {
                _logger.LogInformation("Location request DTO did not map to Location: Invalid input provided");
                throw new Exception("One or more of your inputs are incorrect");
            }

            try
            {
                await _repository.AddAsync(location);
                _logger.LogInformation($"Successfully added location {location.Id} to database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add location: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Deleted location {id} from database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete location {id} from database: {ex.Message}");
                throw;
            }
        }

        public LocationResponseDto Get(string id)
        {
            var location = _repository.Get(id);
            return _mapper.Map<LocationResponseDto>(location);
        }

        public List<LocationResponseDto> GetAll()
        {
            var location = _repository.GetAll();
            return _mapper.Map<List<LocationResponseDto>>(location);
        }

        public async Task UpdateAsync(string id, LocationRequestDto locationRequestDto)
        {
            var location = _repository.Get(id);
            location.Name = locationRequestDto.Name;
            location.Address = locationRequestDto.Address;

            try
            {
                await _repository.UpdateAsync(location);
                _logger.LogInformation($"Updated location {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update location {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
