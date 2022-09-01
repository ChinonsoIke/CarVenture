using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ISession _session;

        public AccountController(IOrderService orderService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _session = httpContextAccessor.HttpContext.Session;
            CultureInfo.CurrentCulture = new CultureInfo("en-NG", false);
        }

        public async Task<IActionResult> Index()
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

            var userId = _session.GetString("UserID");
            var orders = await _orderService.GetAllUserOrdersAsync(userId);
            return View(orders);
        }

        public async Task<IActionResult> OrderHistory()
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

            var userId = _session.GetString("UserID");
            var orders = await _orderService.GetAllUserOrdersAsync(userId);
            return View(orders);
        }
    }
}
