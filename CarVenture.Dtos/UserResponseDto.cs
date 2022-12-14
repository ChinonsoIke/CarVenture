using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin;
        public DateTime CreatedAt;
    }
}
