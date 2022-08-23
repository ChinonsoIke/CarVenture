using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Dtos
{
    public class PostRequestDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string FeatureImagePath { get; set; }
        public string Tag { get; set; }
    }
}
