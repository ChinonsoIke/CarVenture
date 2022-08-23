using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class PostResponseDto
    {
        public string Id = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Body { get; set; }
        public string FeatureImagePath { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}
