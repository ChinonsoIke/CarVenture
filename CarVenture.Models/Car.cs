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
        public string[] Features { get; set; }
        public string ImagePath { get; set; }
    }
}
