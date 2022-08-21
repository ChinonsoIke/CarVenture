using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Models
{
    public class Location
    {
        public string Id = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}
