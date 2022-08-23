using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarVenture.components
{
    public class SearchComponent : ViewComponent
    {
        private readonly ILocationService _locationService;

        public SearchComponent(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IViewComponentResult Invoke()
        {
            var searchModel = new SearchModel();
            var locations = _locationService.GetAll();
            foreach (var location in locations)
            {
                searchModel.Locations.Add(new SelectListItem { Value = location.Id, Text = location.Name });
            }
            return View(searchModel);
        }
    }
}
