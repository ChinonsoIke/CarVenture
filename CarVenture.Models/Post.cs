using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Models
{
    public class Post
    {
        public string Id = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Body { get; set; }
        public string FeatureImagePath { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}
