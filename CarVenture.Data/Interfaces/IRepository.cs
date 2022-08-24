using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Data.Interfaces
{
    /// <summary>
    /// Manages CRUD operations for entities
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Adds an object of type T to the database
        /// </summary>
        /// <param name="item">Object of type T to be added to database</param>
        /// <returns></returns>
        public Task AddAsync(T item);

        /// <summary>
        /// Retrieves an object of type T from the database
        /// </summary>
        /// <param name="id">ID of the object to be retrieved from the database</param>
        /// <returns></returns>
        public T Get(string id);

        /// <summary>
        /// Retrieves all objects of type T from the database
        /// </summary>
        /// <returns>A list of all objects of type T in the database</returns>
        public List<T> GetAll();

        /// <summary>
        /// Updates the value of an object of type T in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task UpdateAsync(T item);

        /// <summary>
        /// Deletes an object of type T from the database
        /// </summary>
        /// <param name="id">ID of the object to be deleted from the database</param>
        /// <returns></returns>
        public Task DeleteAsync(string id);
    }
}
