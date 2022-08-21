using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class CarRequestDto
    {
        public string Name { get; set; }
        public decimal RentPrice { get; set; }
        public string[] Features { get; set; }
        public string ImagePath { get; set; }
        public string LocationId { get; set; }
        public Status Status { get; set; }
    }
}
