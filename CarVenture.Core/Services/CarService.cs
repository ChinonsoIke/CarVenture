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
                await _repository.AddAsync(car);
                _logger.LogInformation($"Successfully added car {car.Id} to database");
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
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Deleted car {id} from database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete car {id} from database: {ex.Message}");
                throw;
            }
        }

        public CarResponseDto Get(string id)
        {
            var car = _repository.Get(id);
            var carResponseDto = _mapper.Map<CarResponseDto>(car);
            carResponseDto.Location = _locationService.Get(carResponseDto.LocationId);
            return carResponseDto;
        }

        public List<CarResponseDto> GetAll()
        {
            var cars = _repository.GetAll();
            var carResponseDtos = _mapper.Map<List<CarResponseDto>>(cars);
            foreach(var carResponseDto in carResponseDtos)
            {
                carResponseDto.Location = _locationService.Get(carResponseDto.LocationId);
            }

            return carResponseDtos;
        }

        public List<CarResponseDto> GetAll(string locationId)
        {
            var cars = _repository.GetAll().Where(c => c.LocationId == locationId);
            var carResponseDtos = _mapper.Map<List<CarResponseDto>>(cars);
            foreach (var carResponseDto in carResponseDtos)
            {
                carResponseDto.Location = _locationService.Get(carResponseDto.LocationId);
            }

            return carResponseDtos;
        }

        public async Task UpdateAsync(string id, CarRequestDto carRequestDto)
        {
            var car = _repository.Get(id);
            car.Name = carRequestDto.Name;
            car.RentPrice = carRequestDto.RentPrice;
            car.Features = carRequestDto.Features;
            car.Status = carRequestDto.Status;
            car.LocationId = carRequestDto.LocationId;
            car.ImagePath = carRequestDto.ImagePath;            

            try
            {
                await _repository.UpdateAsync(car);
                _logger.LogInformation($"Updated car {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update car {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
