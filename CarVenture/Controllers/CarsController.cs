using CarVenture.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
            CultureInfo.CurrentCulture = new CultureInfo("en-NG", false);
        }
        public async Task<IActionResult> Index()
        {
            var cars = (await _carService.GetAllAsync()).Where(c => c.Status == Models.Enums.Status.Available).ToList();
            return View(cars);
        }

        public async Task<IActionResult> Show(string id)
        {
            var carResponseDto = await _carService.GetAsync(id);
            return View(carResponseDto);
        }
    }
}
