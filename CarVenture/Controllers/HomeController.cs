using CarVenture.Core.Interfaces;
using CarVenture.Data;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppService _appService;
        private readonly ICarService _carService;

        public HomeController(ILogger<HomeController> logger, IAppService appService, ICarService carService)
        {
            _logger = logger;
            _appService = appService;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_appService.DBLoaded)
            {
                await _appService.LoadDB();
            }
            
            var model = new HomeViewModel()
            {
                // switch to services, repos, DTOs next week
                Locations = DataStore.Locations,
                Cars = _carService.GetAll(),
                Posts = DataStore.Posts,
            };

            return View(model);
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
