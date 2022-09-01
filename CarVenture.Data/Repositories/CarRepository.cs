using CarVenture.Data.Interfaces;
using CarVenture.Models;
using CarVenture.Models.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarVenture.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public CarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Car car)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCar", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", car.Id);
                    cmd.Parameters.AddWithValue("@Name", car.Name);
                    cmd.Parameters.AddWithValue("@RentPrice", car.RentPrice);
                    cmd.Parameters.AddWithValue("@ImagePath", car.ImagePath);
                    cmd.Parameters.AddWithValue("@LocationId", car.LocationId);
                    cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);
                    cmd.Parameters.AddWithValue("@Status", car.Status);
                    cmd.Parameters.AddWithValue("@Features", car.Features);
                    cmd.Parameters.AddWithValue("@CreatedAt", car.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", car.UpdatedAt);

                    conn.Open();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spDeleteCar", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Car> GetAsync(string id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetCarById", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("Id", id);

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var car = new Car();

                    while (reader.Read())
                    {
                        car.Id = reader["Id"].ToString();
                        car.Name = reader["Name"].ToString();
                        car.RentPrice = (decimal)reader["RentPrice"];
                        car.ImagePath = reader["ImagePath"].ToString();
                        car.LocationId = reader["LocationId"].ToString();
                        car.IsFeatured = (bool)reader["IsFeatured"];
                        car.Status = (Status)reader["Status"];
                        car.Features = reader["Features"].ToString();
                        car.CreatedAt = (DateTime)reader["CreatedAt"];
                        car.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    }

                    return car;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Car>> GetAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetAllCars", conn) { CommandType = CommandType.StoredProcedure };

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var cars = new List<Car>();

                    while (reader.Read())
                    {
                        var car = new Car();
                        car.Id = reader["Id"].ToString();
                        car.Name = reader["Name"].ToString();
                        car.RentPrice = (decimal)reader["RentPrice"];
                        car.ImagePath = reader["ImagePath"].ToString();
                        car.LocationId = reader["LocationId"].ToString();
                        car.IsFeatured = (bool)reader["IsFeatured"];
                        car.Status = (Status)reader["Status"];
                        car.Features = reader["Features"].ToString();
                        car.CreatedAt = (DateTime)reader["CreatedAt"];
                        car.UpdatedAt = (DateTime)reader["UpdatedAt"];

                        cars.Add(car);
                    }

                    return cars;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Car car)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCar", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", car.Id);
                    cmd.Parameters.AddWithValue("@Name", car.Name);
                    cmd.Parameters.AddWithValue("@RentPrice", car.RentPrice);
                    cmd.Parameters.AddWithValue("@ImagePath", car.ImagePath);
                    cmd.Parameters.AddWithValue("@LocationId", car.LocationId);
                    cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);
                    cmd.Parameters.AddWithValue("@Status", car.Status);
                    cmd.Parameters.AddWithValue("@Features", car.Features);
                    cmd.Parameters.AddWithValue("@UpdatedAt", car.UpdatedAt);

                    conn.Open();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
