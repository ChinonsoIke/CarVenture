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
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;
        private readonly ICarService _carService;
        private readonly ILogger _logger;

        public OrderService(IMapper mapper, IOrderRepository repository, ICarService carService, ILogger<OrderService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _carService = carService;
            _logger = logger;
        }

        public async Task AddAsync(OrderRequestDto orderRequestDto)
        {
            var order = _mapper.Map<Order>(orderRequestDto);

            if (order == null)
            {
                _logger.LogInformation("Order request DTO did not map to Order: Invalid input provided");
                throw new Exception("One or more of your inputs are incorrect");
            }

            try
            {
                await _repository.AddAsync(order);
                _logger.LogInformation($"Successfully added order {order.Id} to database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not add order {order.Id} to database: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Deleted order {id} from database");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete order {id} from database: {ex.Message}");
                throw;
            }
        }

        public OrderResponseDto Get(string id)
        {
            var order = _repository.Get(id);
            return _mapper.Map<OrderResponseDto>(order);
        }

        public List<OrderResponseDto> GetAll()
        {
            var orders = _repository.GetAll();
            return _mapper.Map<List<OrderResponseDto>>(orders);
        }

        public List<OrderResponseDto> GetAllUserOrders(string id)
        {
            var orders = _repository.GetAll().Where(o => o.UserId == id);            
            var orderResonseDtos = _mapper.Map<List<OrderResponseDto>>(orders);
            foreach(var order in orderResonseDtos)
            {
                order.Car = _carService.Get(order.CarId);
            }

            return orderResonseDtos;
        }

        public async Task UpdateAsync(string id, OrderRequestDto orderRequestDto)
        {
            var order = _repository.Get(id);
            order.CarId = orderRequestDto.CarId;

            try
            {
                await _repository.UpdateAsync(order);
                _logger.LogInformation($"Updated order {id} information successfully");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update order {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
