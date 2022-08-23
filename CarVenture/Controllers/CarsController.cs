using CarVenture.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarVenture.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            var cars = _carService.GetAll();
            return View(cars);
        }

        public IActionResult Show(string id)
        {
            var carResponseDto = _carService.Get(id);
            return View(carResponseDto);
        }
    }
}
