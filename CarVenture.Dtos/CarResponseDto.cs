using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarVenture.Dtos
{
    public class CarResponseDto
    {
        public string Id = Guid.NewGuid().ToString();
        public string Name { get; set; }
        [Display(Name = "Rent Price")]
        public decimal RentPrice { get; set; }
        public string[] Features { get; set; }
        public string ImagePath { get; set; }
        public string LocationId { get; set; }
        public LocationResponseDto Location { get; set; }
        public Status Status { get; set; }
        public bool IsFeatured { get; set; }
    }
}
