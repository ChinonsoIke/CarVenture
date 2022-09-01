using CarVenture.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        public async Task<IActionResult> Show(string id)
        {
            var carResponseDto = await _carService.GetAsync(id);
            return View(carResponseDto);
        }
    }
}
