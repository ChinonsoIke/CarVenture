using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarVenture.Dtos
{
    public class UserRequestDto
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[@$!%*#?&])(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9@$!%*#?&]{6,}$", ErrorMessage = "Password must be minimum of 6 characters that include alphanumeric and at least one special character (@, #, $, %, ^, &, !)")]
        public string Password { get; set; }
    }
}
