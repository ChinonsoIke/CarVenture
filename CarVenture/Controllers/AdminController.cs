using CarVenture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarVenture.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarService _carService;
        private readonly ILocationService _locationService;
        private readonly IOrderService _orderService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ISession _session;

        public AdminController(IHttpContextAccessor httpContextAccessor, ICarService carService, ILocationService locationService, IOrderService orderService,
            IPostService postService, IUserService userService)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _carService = carService;
            _locationService = locationService;
            _orderService = orderService;
            _postService = postService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");
            if (!_userService.Get(_session.GetString("UserID")).IsAdmin) return NotFound();

            var stats = new Dictionary<string, int>
            {
                {"totalOrders", _orderService.GetAll().Count() },
                {"completedOrders", _orderService.GetAll().Where(o => o.Status == Models.Enums.OrderStatus.Completed).Count() },
                {"totalCars", _carService.GetAll().Count() },
                {"totalLocations", _locationService.GetAll().Count() },
                {"totalPosts", _postService.GetAll().Count() },
                {"totalUsers", _userService.GetAll().Count() },
            };

            return View(stats);
        }

        public IActionResult Cars()
        {
            if (_session.GetString("UserID") == null || !_userService.Get(_session.GetString("UserID")).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var cars = _carService.GetAll();
            return View(cars);
        }

        public IActionResult Locations()
        {
            if (_session.GetString("UserID") == null || !_userService.Get(_session.GetString("UserID")).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var locations = _locationService.GetAll();
            return View(locations);
        }

        public IActionResult Orders()
        {
            if (_session.GetString("UserID") == null || !_userService.Get(_session.GetString("UserID")).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var orders = _orderService.GetAll();
            return View(orders);
        }

        public IActionResult Posts()
        {
            if (_session.GetString("UserID") == null || !_userService.Get(_session.GetString("UserID")).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var posts = _postService.GetAll();
            return View(posts);
        }

        public IActionResult Users()
        {
            if (_session.GetString("UserID") == null || !_userService.Get(_session.GetString("UserID")).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var users = _userService.GetAll();
            return View(users);
        }
    }
}
