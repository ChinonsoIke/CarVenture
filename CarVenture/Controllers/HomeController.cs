using CarVenture.Core.Interfaces;
using CarVenture.Data;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
        private readonly ILocationService _locationService;
        private readonly IPostService _postService;

        public HomeController(ILogger<HomeController> logger, ICarService carService, ILocationService locationService, IPostService postService)
        {
            _logger = logger;
            _carService = carService;
            _locationService = locationService;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {            
            var data = new HomeViewModel()
            {
                Cars = await _carService.GetAllAsync(),
                Locations = await _locationService.GetAllAsync(),
                Posts = await _postService.GetAllAsync(),
            };

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
