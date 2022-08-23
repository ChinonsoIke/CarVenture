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
    public class OrderRepository : IOrderRepository
    {
        public async Task AddAsync(Order order)
        {
            DataStore.Orders.Add(order);
            try
            {
                await WriteJsonAsync(DataStore.Orders, ordersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            DataStore.Orders.RemoveAll(o => o.Id == id);
            try
            {
                await WriteJsonAsync(DataStore.Orders, ordersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order Get(string id)
        {
            return DataStore.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return DataStore.Orders;
        }

        public async Task UpdateAsync(Order order)
        {
            try
            {
                var index = DataStore.Orders.IndexOf(DataStore.Orders.First(o => o.Id == order.Id));
                DataStore.Orders[index] = order;

                await WriteJsonAsync(DataStore.Orders, ordersFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
