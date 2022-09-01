using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Models
{
    public class Car
    {
        public string Id = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public decimal RentPrice { get; set; }
        public string Features { get; set; }
        public string ImagePath { get; set; }
        public string LocationId { get; set; }
        public Status Status { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}
