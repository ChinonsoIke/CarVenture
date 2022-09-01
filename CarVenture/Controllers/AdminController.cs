using CarVenture.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
            CultureInfo.CurrentCulture = new CultureInfo("en-NG", false);
        }

        public async Task<IActionResult> Index()
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");
            if (!(await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin) return NotFound();

            var stats = new Dictionary<string, int>
            {
                {"totalOrders", (await _orderService.GetAllAsync()).Count() },
                {"completedOrders", (await _orderService.GetAllAsync()).Where(o => o.Status == Models.Enums.OrderStatus.Completed).Count() },
                {"totalCars", (await _carService.GetAllAsync()).Count() },
                {"totalLocations", (await _locationService.GetAllAsync()).Count() },
                {"totalPosts", (await _postService.GetAllAsync()).Count() },
                {"totalUsers", (await _userService.GetAllAsync()).Count() },
            };

            return View(stats);
        }

        public async Task<IActionResult> Cars()
        {
            if (_session.GetString("UserID") == null || ! (await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        public async Task<IActionResult> Locations()
        {
            if (_session.GetString("UserID") == null || !(await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var locations = await _locationService.GetAllAsync();
            return View(locations);
        }

        public async Task<IActionResult> Orders()
        {
            if (_session.GetString("UserID") == null || !(await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var orders = await _orderService.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> Posts()
        {
            if (_session.GetString("UserID") == null || !(await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var posts = await _postService.GetAllAsync();
            return View(posts);
        }

        public async Task<IActionResult> Users()
        {
            if (_session.GetString("UserID") == null || !(await _userService.GetAsync(_session.GetString("UserID"))).IsAdmin)
                return RedirectToAction("Login", "Auth");

            var users = await _userService.GetAllAsync();
            return View(users);
        }
    }
}
