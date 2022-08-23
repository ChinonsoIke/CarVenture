using CarVenture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Interfaces
{
    public interface IOrderService : IService<OrderRequestDto, OrderResponseDto>
    {
        public List<OrderResponseDto> GetAllUserOrders(string id);
    }
}
