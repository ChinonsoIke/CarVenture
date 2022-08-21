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
    public class CarRepository : ICarRepository
    {
        public async Task AddAsync(Car car)
        {
            DataStore.Cars.Add(car);
            try
            {
                await WriteJsonAsync(DataStore.Cars, carsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            DataStore.Cars.RemoveAll(c => c.Id == id);
            try
            {
                await WriteJsonAsync(DataStore.Cars, carsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Car Get(string id)
        {
            return DataStore.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return DataStore.Cars;
        }

        public async Task UpdateAsync(Car car)
        {
            try
            {
                var index = DataStore.Cars.IndexOf(DataStore.Cars.First(c => c.Id == car.Id));
                DataStore.Cars[index] = car;

                await WriteJsonAsync(DataStore.Cars, carsFile);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
