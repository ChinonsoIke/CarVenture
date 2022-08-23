using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult LocationSearch(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                var cars = _carService.GetAll(searchModel.LocationId);
                return View(cars);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
