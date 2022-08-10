﻿using System.Collections.Generic;

namespace CarVenture.Models
{
    public class HomeViewModel
    {
        public List<Location> Locations { get; set; }
        public List<Car> Cars { get; set; }
        public List<Post> Posts { get; set; }
    }
}