using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarVenture.Helpers
{
    public class FileOperations
    {
        public static string dbPath = Path.Combine(Environment.CurrentDirectory, "db");
        public static readonly string usersFile = Path.Combine(dbPath, "users.json");
        public static readonly string carsFile = Path.Combine(dbPath, "cars.json");
        public static readonly string locationsFile = Path.Combine(dbPath, "locations.json");
        public static readonly string ordersFile = Path.Combine(dbPath, "orders.json");
        public static readonly string orderDetailsFile = Path.Combine(dbPath, "order_details.json");
        public static readonly string postsFile = Path.Combine(dbPath, "post.json");

        public static async Task WriteJsonAsync<T>(T obj, string path)
        {
            if (!Directory.Exists(dbPath)) Directory.CreateDirectory(dbPath);
            try
            {
                string json = JsonConvert.SerializeObject(obj) + Environment.NewLine;
                await File.WriteAllTextAsync(path, json);
            }
            catch (Exception)
            {

                throw new Exception("Cannot write to database");
            }
        }

        public static async Task<List<T>> ReadJsonAsync<T>(string path)
        {
            var readText = await File.ReadAllTextAsync(path);

            return JsonConvert.DeserializeObject<List<T>>(readText);
        }
    }
}
