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
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _repository;
        private readonly ILogger<UserService> _logger;

        public CarService(IMapper mapper, ICarRepository repository, ILogger<UserService> logger)
        {
            _mapper = mapper;
            _repository = repository;
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
            return _mapper.Map<CarResponseDto>(car);
        }

        public List<CarResponseDto> GetAll()
        {
            var cars = _repository.GetAll();
            return _mapper.Map<List<CarResponseDto>>(cars);
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
