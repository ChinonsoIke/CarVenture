using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarService _carService;

        public SearchController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LocationSearch(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                var cars = await _carService.GetAllAsync(searchModel.LocationId);
                return View(cars);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
