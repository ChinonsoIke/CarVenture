using CarVenture.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarVenture.Models
{
    public class SearchModel
    {
        public List<SelectListItem> Locations = new List<SelectListItem>();
        public string LocationId { get; set; }
        [Required]
        [RegularExpression(@"^\d{1,2}/\d{1,2}/\d{4}")]
        public string PickupDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{1,2}/\d{1,2}/\d{4}")]
        public string ReturnDate { get; set; }
    }
}
