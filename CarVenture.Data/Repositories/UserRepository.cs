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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spAddUser", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Firstname", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", user.UpdatedAt);

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
                    var cmd = new SqlCommand("spDeleteUser", conn) { CommandType = CommandType.StoredProcedure };
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

        public async Task<User> GetAsync(string identification)
        {

            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetUserById", conn) { CommandType = CommandType.StoredProcedure };

                    if (identification.Contains('@'))
                    {
                        cmd.CommandText = "spGetUserByEmail";
                        cmd.Parameters.AddWithValue("Email", identification);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Id", identification);
                    }
                    

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var user = new User();

                    while (reader.Read())
                    {
                        user.Id = reader["Id"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                        user.IsAdmin = (bool)reader["IsAdmin"];
                        user.CreatedAt = (DateTime)reader["CreatedAt"];
                        user.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    }

                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetAllUsers", conn) { CommandType = CommandType.StoredProcedure };


                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var users = new List<User>();

                    while (reader.Read())
                    {
                        var user = new User();
                        user.Id = reader["Id"].ToString();
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                        user.IsAdmin = (bool)reader["IsAdmin"];
                        user.CreatedAt = (DateTime)reader["CreatedAt"];
                        user.UpdatedAt = (DateTime)reader["UpdatedAt"];
                        users.Add(user);
                    }

                    return users;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateUser", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Firstname", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    cmd.Parameters.AddWithValue("@UpdatedAt", user.UpdatedAt);

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
