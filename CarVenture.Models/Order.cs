using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Models
{
    public class Order
    {
        public string Id = Guid.NewGuid().ToString();
        public string CarId { get; set; }
        public string UserId { get; set; }
        public OrderStatus Status = OrderStatus.Processing;
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}
