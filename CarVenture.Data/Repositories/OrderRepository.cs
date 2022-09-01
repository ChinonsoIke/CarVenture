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
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spAddOrder", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@CarId", order.CarId);
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PriceTotal", order.PriceTotal);
                    cmd.Parameters.AddWithValue("@PickupDate", order.PickupDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", order.ReturnDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@CreatedAt", order.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", order.UpdatedAt);

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

        public async Task<Order> GetAsync(string id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetOrderById", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("Id", id);

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var order = new Order();

                    while (reader.Read())
                    {
                        order.Id = reader["Id"].ToString();
                        order.CarId = reader["CarId"].ToString();
                        order.UserId = reader["UserId"].ToString();
                        order.PriceTotal = (decimal)reader["PriceTotal"];
                        order.Status = (OrderStatus)reader["Status"];
                        order.PickupDate = (DateTime)reader["PickupDate"];
                        order.ReturnDate = (DateTime)reader["ReturnDate"];
                        order.CreatedAt = (DateTime)reader["CreatedAt"];
                        order.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    }

                    return order;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetAllOrders", conn) { CommandType = CommandType.StoredProcedure };

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var orders = new List<Order>();

                    while (reader.Read())
                    {
                        var order = new Order();
                        order.Id = reader["Id"].ToString();
                        order.CarId = reader["CarId"].ToString();
                        order.UserId = reader["UserId"].ToString();
                        order.PriceTotal = (decimal)reader["PriceTotal"];
                        order.Status = (OrderStatus)reader["Status"];
                        order.PickupDate = (DateTime)reader["PickupDate"];
                        order.ReturnDate = (DateTime)reader["ReturnDate"];
                        order.CreatedAt = (DateTime)reader["CreatedAt"];
                        order.UpdatedAt = (DateTime)reader["UpdatedAt"];

                        orders.Add(order);
                    }

                    return orders;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateOrder", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@CarId", order.CarId);
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@PriceTotal", order.PriceTotal);
                    cmd.Parameters.AddWithValue("@PickupDate", order.PickupDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", order.ReturnDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@UpdatedAt", order.UpdatedAt);

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
