using CarVenture.Models;
using CarVenture.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarVenture.Data
{
    public class DataStore
    {
        public static List<Location> Locations = new List<Location>
        {
            new Location()
            {
                Name = "Lekki"
            },
            new Location()
            {
                Name = "Ikeja"
            },
            new Location()
            {
                Name = "Oshodi"
            },
        };

        public static List<Car> Cars = new List<Car>
        {
            new Car(){
                Name = "Toyota Corolla T-20",
                RentPrice = 50000m,
                Features = new string[] {"Air Conditioned", "Bluetooth Sound System", "Sunroof Available" },
                ImagePath = "~images/Car\\ Image.png",
                LocationId = Locations.First(x => x.Name == "Ikeja").Id,
                Status = Status.Available
            },
            new Car(){
                Name = "Toyota Corolla T-25",
                RentPrice = 60000m,
                Features = new string[] {"Air Conditioned", "Bluetooth Sound System", "GPS System" },
                ImagePath = "~images/Car\\ Image2.png",
                LocationId = Locations.First(x => x.Name == "Lekki").Id,
                Status = Status.Available
            },
            new Car(){
                Name = "Toyota Corolla T-30",
                RentPrice = 75000m,
                Features = new string[] {"Air Conditioned", "Bluetooth Sound System", "Suicide Doors" },
                ImagePath = "~images/Car\\ Image3.png",
                LocationId = Locations.First(x => x.Name == "Oshodi").Id,
                Status = Status.Available
            },
        };

        public static List<PostTag> Tags = new List<PostTag>
        {
            new PostTag()
            {
                Name = "safety"
            },
            new PostTag()
            {
                Name = "affordable"
            },
            new PostTag()
            {
                Name = "cruise"
            },
            new PostTag()
            {
                Name = "general"
            },
        };

        public static List<Post> Posts = new List<Post>
        {
            new Post()
            {
                Title = "Caring is the new Marketing",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit."
                Tag = Tags.First(x => x.Name == "affordable")
            },
            new Post()
            {
                Title = "We All Need Cars",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit."
                Tag = Tags.First(x => x.Name == "safety")
            },
            new Post()
            {
                Title = "Cars are Necessary for Cruise",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit."
                Tag = Tags.First(x => x.Name == "cruise")
            },
        };
    }
}
