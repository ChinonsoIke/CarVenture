using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarService _carService;

        public SearchController(ICarService carService)
        {
            _carService = carService;
            CultureInfo.CurrentCulture = new CultureInfo("en-NG", false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LocationSearch(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                var cars = (await _carService.GetAllAsync(searchModel.LocationId)).Where(c => c.Status == Models.Enums.Status.Available).ToList();
                return View(cars);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
