using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        }
        public IActionResult Index()
        {
            var userId = _session.GetString("UserID");
            var orders = _orderService.GetAllUserOrders(userId);
            return View(orders);
        }

        public IActionResult OrderHistory()
        {
            var userId = _session.GetString("UserID");
            var orders = _orderService.GetAllUserOrders(userId);
            return View(orders);
        }
    }
}
