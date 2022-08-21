using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarVenture.Models
{
    public class User
    {
        public string Id = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}
