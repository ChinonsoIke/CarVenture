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
                Name = "Lekki",
                Address = "12 Pineapple Road, Lekki Phase 1"
            },
            new Location()
            {
                Name = "Ikeja",
                Address = "16 Oshitelu Street, Ikeja GRA"
            },
            new Location()
            {
                Name = "Oshodi",
                Address = "1 Noxx Avenue, Oshodi"
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

        public static List<Post> Posts = new List<Post>
        {
            new Post()
            {
                Title = "Caring is the new Marketing",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = "affordable",
                FeatureImagePath = "/images/Blog Image2.png"
            },
            new Post()
            {
                Title = "We All Need Cars",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = "safety",
                FeatureImagePath = "/images/Blog Image3.png"
            },
            new Post()
            {
                Title = "Cars are Necessary for Cruise",
                Body = "Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit. Amet minim mollit non deserunt ullamco est sit aliqua dolor do amet sint. Velit officia consequat duis enim velit mollit.",
                Tag = "cruise",
                FeatureImagePath = "/images/Blog Image.png"
            },
        };

        public static List<Order> Orders = new List<Order>();

        public static async Task LoadDatabaseAsync()
        {
            try
            {
                if(File.Exists(usersFile)) Users = await ReadJsonAsync<User>(usersFile) ?? Users;
                if (File.Exists(carsFile)) Cars = await ReadJsonAsync<Car>(carsFile) ?? Cars;
                if (File.Exists(locationsFile)) Locations = await ReadJsonAsync<Location>(locationsFile) ?? Locations;
                if (File.Exists(ordersFile)) Orders = await ReadJsonAsync<Order>(ordersFile) ?? Orders;
                if (File.Exists(postsFile)) Posts = await ReadJsonAsync<Post>(postsFile) ?? Posts;
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
                await WriteJsonAsync(Posts, postsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
