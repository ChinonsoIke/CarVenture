using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Interfaces
{
    public interface IService<TRequestDto, TResponseDto>
    {
        /// <summary>
        /// Converts a data transfer object of type TRequestDto
        /// to a domain entity object to be stored in the database
        /// </summary>
        /// <param name="item">Data transfer object representing the domain entity</param>
        /// <returns></returns>
        public Task AddAsync(TRequestDto item);

        /// <summary>
        /// Retrieves a domain entity from the database an converts it to a data
        /// transfer object
        /// </summary>
        /// <param name="id">ID of the object to be retrieved from the database</param>
        /// <returns>A data transfer object representing the domain entity</returns>
        public Task<TResponseDto> GetAsync(string id);

        /// <summary>
        /// Retrieves all objects match TResponseDto from the database and 
        /// converts them to type TResponseDto
        /// </summary>
        /// <returns>A list of objects of type TResponseDto</returns>
        public Task<List<TResponseDto>> GetAllAsync();

        /// <summary>
        /// Converts a data transfer object of type TRequestDto
        /// to a matching domain entity object to be updated in the database
        /// </summary>
        /// <param name="id">ID of ddomain entity object to be retrieved from the database and updated</param>
        /// <param name="item">Data transfer object representing the domain entity</param>
        /// <returns></returns>
        public Task UpdateAsync(string id, TRequestDto item);

        /// <summary>
        /// Deletes a domain entity object from the database
        /// </summary>
        /// <param name="id">ID of the object to be deleted from the database</param>
        /// <returns></returns>
        public Task DeleteAsync(string id);
    }
}
