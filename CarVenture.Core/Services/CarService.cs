using AutoMapper;
using CarVenture.Core.Interfaces;
using CarVenture.Data.Interfaces;
using CarVenture.Dtos;
using CarVenture.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _repository;
        private readonly ILocationService _locationService;
        private readonly ILogger _logger;

        public CarService(IMapper mapper, ICarRepository repository, ILocationService locationService, ILogger<CarService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _locationService = locationService;
            _logger = logger;
        }
        public async Task AddAsync(CarRequestDto carRequestDto)
        {
            var car = _mapper.Map<Car>(carRequestDto);

            if (car == null)
            {
                _logger.LogInformation("Car DTO did not map to Car: Invalid input provided");
                throw new Exception("One or more of your inputs are incorrect");
            }

            try
            {   
                if(await _repository.AddAsync(car) > 0)
                {
                    _logger.LogInformation($"Successfully added car {car.Id} to database");
                }
                else
                {
                    _logger.LogInformation($"Could not add car {car.Id} to database: zero rows affected");
                    throw new Exception($"Could not add car {car.Id} to database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add car {car.Id} to database: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                if (await _repository.DeleteAsync(id) > 0)
                {
                    _logger.LogInformation($"Deleted car {id} from database");
                }
                else
                {
                    _logger.LogInformation($"Could not delete car {id} from database: zero rows affected");
                    throw new Exception($"Could not delete car {id} from database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete car {id} from database: {ex.Message}");
                throw;
            }
        }

        public async Task<CarResponseDto> GetAsync(string id)
        {
            var car = await _repository.GetAsync(id);
            var carResponseDto = _mapper.Map<CarResponseDto>(car);
            carResponseDto.Location = await _locationService.GetAsync(carResponseDto.LocationId);
            return carResponseDto;
        }

        public async Task<List<CarResponseDto>> GetAllAsync()
        {
            var cars = await _repository.GetAllAsync();
            var carResponseDtos = _mapper.Map<List<CarResponseDto>>(cars);
            foreach(var carResponseDto in carResponseDtos)
            {
                carResponseDto.Location = await _locationService.GetAsync(carResponseDto.LocationId);
            }

            return carResponseDtos;
        }

        public async Task<List<CarResponseDto>> GetAllAsync(string locationId)
        {
            var allCars = await _repository.GetAllAsync();
            var cars = allCars.Where(c => c.LocationId == locationId);
            var carResponseDtos = _mapper.Map<List<CarResponseDto>>(cars);
            foreach (var carResponseDto in carResponseDtos)
            {
                carResponseDto.Location = await _locationService.GetAsync(carResponseDto.LocationId);
            }

            return carResponseDtos;
        }

        public async Task UpdateAsync(string id, CarRequestDto carRequestDto)
        {
            var car = await _repository.GetAsync(id);
            car.Name = carRequestDto.Name;
            car.RentPrice = carRequestDto.RentPrice;
            car.Features = carRequestDto.Features;
            car.Status = carRequestDto.Status;
            car.LocationId = carRequestDto.LocationId;
            car.ImagePath = carRequestDto.ImagePath;
            car.UpdatedAt = DateTime.Now;

            try
            {
                if (await _repository.UpdateAsync(car) > 0)
                {
                    _logger.LogInformation($"Updated car {id} information successfully");
                }
                else
                {
                    _logger.LogInformation($"Could not update car {id} information: zero rows affected");
                    throw new Exception($"Could not update car {id} information: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update car {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
