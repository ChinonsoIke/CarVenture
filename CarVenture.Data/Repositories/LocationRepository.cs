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
    public class LocationRepository : ILocationRepository
    {
        public async Task AddAsync(Location location)
        {
            DataStore.Locations.Add(location);
            try
            {
                await WriteJsonAsync(DataStore.Locations, locationsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            DataStore.Locations.RemoveAll(l => l.Id == id);
            try
            {
                await WriteJsonAsync(DataStore.Locations, locationsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Location Get(string id)
        {
            return DataStore.Locations.FirstOrDefault(l => l.Id == id);
        }

        public List<Location> GetAll()
        {
            return DataStore.Locations;
        }

        public async Task UpdateAsync(Location location)
        {
            try
            {
                var index = DataStore.Locations.IndexOf(DataStore.Locations.First(l => l.Id == location.Id));
                DataStore.Locations[index] = location;

                await WriteJsonAsync(DataStore.Locations, locationsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
