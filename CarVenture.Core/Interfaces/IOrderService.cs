using CarVenture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Interfaces
{
    public interface IOrderService : IService<OrderRequestDto, OrderResponseDto>
    {
        /// <summary>
        /// Gets all Order objects that have the matching UserId property
        /// </summary>
        /// <param name="id">string user ID</param>
        /// <returns>A list of OrderResponseDto objects</returns>
        public List<OrderResponseDto> GetAllUserOrders(string id);
    }
}
