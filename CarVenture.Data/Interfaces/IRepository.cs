using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Data.Interfaces
{
    public interface IRepository<T>
    {
        public Task AddAsync(T item);
        public T Get(string id);
        public List<T> GetAll();
        public Task UpdateAsync(T item);
        public Task DeleteAsync(string id);
    }
}
