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
                if (await _repository.AddAsync(location) > 0)
                {
                    _logger.LogInformation($"Successfully added location {location.Id} to database");
                }
                else
                {
                    _logger.LogInformation($"Could not add location {location.Id} to database: zero rows affected");
                    throw new Exception($"Could not add location {location.Id} to database: zero rows affected");
                }
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
                if (await _repository.DeleteAsync(id) > 0)
                {
                    _logger.LogInformation($"Deleted location {id} from database");
                }
                else
                {
                    _logger.LogInformation($"Could not delete location {id} from database: zero rows affected");
                    throw new Exception($"Could not delete location {id} from database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete location {id} from database: {ex.Message}");
                throw;
            }
        }

        public async Task<LocationResponseDto> GetAsync(string id)
        {
            var location = await _repository.GetAsync(id);
            return _mapper.Map<LocationResponseDto>(location);
        }

        public async Task<List<LocationResponseDto>> GetAllAsync()
        {
            var locations = await _repository.GetAllAsync();
            return _mapper.Map<List<LocationResponseDto>>(locations);
        }

        public async Task UpdateAsync(string id, LocationRequestDto locationRequestDto)
        {
            var location = await _repository.GetAsync(id);
            location.Name = locationRequestDto.Name;
            location.Address = locationRequestDto.Address;
            location.UpdatedAt = DateTime.Now;

            try
            {
                if (await _repository.UpdateAsync(location) > 0)
                {
                    _logger.LogInformation($"Updated location {id} information successfully");
                }
                else
                {
                    _logger.LogInformation($"Could not update location {id} information: zero rows affected");
                    throw new Exception($"Could not update location {id} information: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update location {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
