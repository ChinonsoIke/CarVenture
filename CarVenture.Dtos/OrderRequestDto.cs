using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarVenture.Dtos
{
    public class OrderRequestDto
    {
        public string CarId { get; set; }
        public string UserId { get; set; }
        public decimal PriceTotal { get; set; }
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
