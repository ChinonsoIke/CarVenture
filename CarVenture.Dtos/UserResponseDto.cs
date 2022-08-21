using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class UserResponseDto
    {
        public string Id { get; }
        public string FullName { get; }
        public string Email { get; set; }
    }
}
