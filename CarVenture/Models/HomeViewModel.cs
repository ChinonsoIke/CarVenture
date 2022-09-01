using CarVenture.Dtos;
using System.Collections.Generic;

namespace CarVenture.Models
{
    public class HomeViewModel
    {
        public List<LocationResponseDto> Locations { get; set; }
        public List<CarResponseDto> Cars { get; set; }
        public List<PostResponseDto> Posts { get; set; }
    }
}
