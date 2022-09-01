using CarVenture.Data.Interfaces;
using CarVenture.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CarVenture.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Location location)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spAddLocation", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", location.Id);
                    cmd.Parameters.AddWithValue("@Name", location.Name);
                    cmd.Parameters.AddWithValue("@Address", location.Address);
                    cmd.Parameters.AddWithValue("@CreatedAt", location.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", location.UpdatedAt);

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
                    var cmd = new SqlCommand("spDeleteLocation", conn) { CommandType = CommandType.StoredProcedure };
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

        public async Task<Location> GetAsync(string id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetLocationById", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("Id", id);

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var location = new Location();

                    while (reader.Read())
                    {
                        location.Id = reader["Id"].ToString();
                        location.Name = reader["Name"].ToString();
                        location.Address = reader["Address"].ToString();
                        location.CreatedAt = (DateTime)reader["CreatedAt"];
                        location.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    }

                    return location;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Location>> GetAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetAllLocations", conn) { CommandType = CommandType.StoredProcedure };

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var locations = new List<Location>();

                    while (reader.Read())
                    {
                        var location = new Location();
                        location.Id = reader["Id"].ToString();
                        location.Name = reader["Name"].ToString();
                        location.Address = reader["Address"].ToString();
                        location.CreatedAt = (DateTime)reader["CreatedAt"];
                        location.UpdatedAt = (DateTime)reader["UpdatedAt"];

                        locations.Add(location);
                    }

                    return locations;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Location location)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateLocation", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", location.Id);
                    cmd.Parameters.AddWithValue("@Name", location.Name);
                    cmd.Parameters.AddWithValue("@Address", location.Address);
                    cmd.Parameters.AddWithValue("@UpdatedAt", location.UpdatedAt);

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
