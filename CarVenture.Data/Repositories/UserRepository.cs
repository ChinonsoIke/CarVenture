using CarVenture.Data.Interfaces;
using CarVenture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CarVenture.Helpers.FileOperations;

namespace CarVenture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            DataStore.Users.Add(user);
            try
            {
                await WriteJsonAsync(DataStore.Users, usersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            DataStore.Users.RemoveAll(u => u.Id == id);
            try
            {
                await WriteJsonAsync(DataStore.Users, usersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Get(string identification)
        {
            return DataStore.Users.FirstOrDefault(u => u.Id == identification || u.Email == identification);
        }

        public List<User> GetAll()
        {
            return DataStore.Users;
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                var index = DataStore.Users.IndexOf(DataStore.Users.First(u => u.Id == user.Id));
                DataStore.Users[index] = user;

                await WriteJsonAsync(DataStore.Users, usersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
