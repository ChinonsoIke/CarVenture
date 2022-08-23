using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class LocationResponseDto
    {
        public string Id = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
