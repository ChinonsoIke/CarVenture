using CarVenture.Data.Interfaces;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarVenture.Helpers.FileOperations;

namespace CarVenture.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task AddAsync(Post post)
        {
            DataStore.Posts.Add(post);
            try
            {
                await WriteJsonAsync(DataStore.Posts, postsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            DataStore.Posts.RemoveAll(p => p.Id == id);
            try
            {
                await WriteJsonAsync(DataStore.Posts, postsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Post Get(string id)
        {
            return DataStore.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAll()
        {
            return DataStore.Posts;
        }

        public async Task UpdateAsync(Post post)
        {
            try
            {
                var index = DataStore.Posts.IndexOf(DataStore.Posts.First(p => p.Id == post.Id));
                DataStore.Posts[index] = post;

                await WriteJsonAsync(DataStore.Posts, postsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
