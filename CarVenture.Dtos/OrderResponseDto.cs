using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class OrderResponseDto
    {
        public string Id = Guid.NewGuid().ToString();
        public string CarId { get; set; }
        public CarResponseDto Car { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt;
    }
}
