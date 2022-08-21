using CarVenture.Models;
using CarVenture.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarVenture.Helpers.FileOperations;

namespace CarVenture.Data
{
    public class DataStore
    {
        public static List<User> Users = new List<User>();

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
                ImagePath = "/images/Car Image.png",
                LocationId = Locations.First(x => x.Name == "Ikeja").Id,
                Status = Status.Available,
                IsFeatured = true,
            },
            new Car(){
                Name = "Toyota Corolla T-25",
                RentPrice = 60000m,
                Features = new string[] {"Air Conditioned", "Bluetooth Sound System", "GPS System" },
                ImagePath = "/images/Car Image2.png",
                LocationId = Locations.First(x => x.Name == "Lekki").Id,
                Status = Status.Available,
                IsFeatured = true,
            },
            new Car(){
                Name = "Toyota Corolla T-30",
                RentPrice = 75000m,
                Features = new string[] {"Air Conditioned", "Bluetooth Sound System", "Suicide Doors" },
                ImagePath = "/images/Car Image3.png",
                LocationId = Locations.First(x => x.Name == "Oshodi").Id,
                Status = Status.Available,
                IsFeatured = true,
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
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = Tags.First(x => x.Name == "affordable"),
                FeatureImagePath = "/images/Blog Image2.png"
            },
            new Post()
            {
                Title = "We All Need Cars",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = Tags.First(x => x.Name == "safety"),
                FeatureImagePath = "/images/Blog Image3.png"
            },
            new Post()
            {
                Title = "Cars are Necessary for Cruise",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = Tags.First(x => x.Name == "cruise"),
                FeatureImagePath = "/images/Blog Image.png"
            },
        };

        public static List<Order> Orders = new List<Order>();

        public static List<OrderDetail> OrderDetails = new List<OrderDetail>();

        public static async Task LoadDatabaseAsync()
        {
            try
            {
                Users = await ReadJsonAsync<User>(usersFile) ?? Users;
                //Cars = await ReadJsonAsync<Car>(carsFile) ?? Cars;
                //Locations = await ReadJsonAsync<Location>(locationsFile) ?? Locations;
                //Orders = await ReadJsonAsync<Order>(ordersFile) ?? Orders;
                //OrderDetails = await ReadJsonAsync<OrderDetail>(orderDetailsFile) ?? OrderDetails;
                //Posts = await ReadJsonAsync<Post>(postsFile) ?? Posts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task SaveToDatabaseAsync()
        {
            if (!Directory.Exists(dbPath)) Directory.CreateDirectory(dbPath);
            try
            {
                await WriteJsonAsync(Users, usersFile);
                await WriteJsonAsync(Cars, carsFile);
                await WriteJsonAsync(Locations, locationsFile);
                await WriteJsonAsync(Orders, ordersFile);
                await WriteJsonAsync(OrderDetails, orderDetailsFile);
                await WriteJsonAsync(Posts, postsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
