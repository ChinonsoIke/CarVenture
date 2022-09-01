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
    public class PostRepository : IPostRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public PostRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddAsync(Post post)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spAddPost", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", post.Id);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@Body", post.Body);
                    cmd.Parameters.AddWithValue("@Tag", post.Tag);
                    cmd.Parameters.AddWithValue("@FeatureImagePath", post.FeatureImagePath);
                    cmd.Parameters.AddWithValue("@CreatedAt", post.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", post.UpdatedAt);

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
                    var cmd = new SqlCommand("spDeletePost", conn) { CommandType = CommandType.StoredProcedure };
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

        public async Task<Post> GetAsync(string id)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetOrderById", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("Id", id);

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var post = new Post();

                    while (reader.Read())
                    {
                        post.Id = reader["Id"].ToString();
                        post.Title = reader["Title"].ToString();
                        post.Body = reader["Body"].ToString();
                        post.Tag = reader["Tag"].ToString();
                        post.FeatureImagePath = reader["FeatureImagePath"].ToString();
                        post.CreatedAt = (DateTime)reader["CreatedAt"];
                        post.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    }

                    return post;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Post>> GetAllAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand("spGetAllPosts", conn) { CommandType = CommandType.StoredProcedure };

                    conn.Open();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    var posts = new List<Post>();

                    while (reader.Read())
                    {
                        var post = new Post();
                        post.Id = reader["Id"].ToString();
                        post.Title = reader["Title"].ToString();
                        post.Body = reader["Body"].ToString();
                        post.Tag = reader["Tag"].ToString();
                        post.FeatureImagePath = reader["FeatureImagePath"].ToString();
                        post.CreatedAt = (DateTime)reader["CreatedAt"];
                        post.UpdatedAt = (DateTime)reader["UpdatedAt"];

                        posts.Add(post);
                    }

                    return posts;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Post post)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdatePost", conn) { CommandType = CommandType.StoredProcedure };

                    // Add command parameters
                    cmd.Parameters.AddWithValue("@Id", post.Id);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@Body", post.Body);
                    cmd.Parameters.AddWithValue("@Tag", post.Tag);
                    cmd.Parameters.AddWithValue("@FeatureImagePath", post.FeatureImagePath);
                    cmd.Parameters.AddWithValue("@UpdatedAt", post.UpdatedAt);

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
