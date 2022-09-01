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
                if (await _repository.AddAsync(order) > 0)
                {
                    _logger.LogInformation($"Successfully added order {order.Id} to database");
                }
                else
                {
                    _logger.LogInformation($"Could not add order {order.Id} to database: zero rows affected");
                    throw new Exception($"Could not add order {order.Id} to database: zero rows affected");
                }
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
                if (await _repository.DeleteAsync(id) > 0)
                {
                    _logger.LogInformation($"Deleted order {id} from database");
                }
                else
                {
                    _logger.LogInformation($"Could not delete order {id} from database: zero rows affected");
                    throw new Exception($"Could not delete order {id} from database: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not delete order {id} from database: {ex.Message}");
                throw;
            }
        }

        public async Task<OrderResponseDto> GetAsync(string id)
        {
            var order = await _repository.GetAsync(id);
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<List<OrderResponseDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderResponseDto>>(orders);
        }

        public async Task<List<OrderResponseDto>> GetAllUserOrdersAsync(string id)
        {
            var allOrders = await _repository.GetAllAsync();
            var orders = allOrders.Where(o => o.UserId == id);
            var orderResonseDtos = _mapper.Map<List<OrderResponseDto>>(orders);
            foreach(var order in orderResonseDtos)
            {
                order.Car =await _carService.GetAsync(order.CarId);
            }

            return orderResonseDtos;
        }

        public async Task UpdateAsync(string id, OrderRequestDto orderRequestDto)
        {
            var order = await _repository.GetAsync(id);
            order.CarId = orderRequestDto.CarId;
            order.UserId = orderRequestDto.UserId;
            order.PickupDate = orderRequestDto.PickupDate;
            order.ReturnDate = orderRequestDto.ReturnDate;
            order.PriceTotal = orderRequestDto.PriceTotal;
            order.Status = orderRequestDto.Status;
            order.UpdatedAt = DateTime.Now;

            try
            {
                if (await _repository.UpdateAsync(order) > 0)
                {
                    _logger.LogInformation($"Updated order {id} information successfully");
                }
                else
                {
                    _logger.LogInformation($"Could not update order {id} information: zero rows affected");
                    throw new Exception($"Could not update order {id} information: zero rows affected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Could not update order {id} information: {ex.Message}");
                throw;
            }
        }
    }
}
