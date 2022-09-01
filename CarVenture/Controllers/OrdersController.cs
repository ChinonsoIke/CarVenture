using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly ISession _session;

        public OrdersController(ICarService carService, IUserService userService, IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _carService = carService;
            _userService = userService;
            _orderService = orderService;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

            var orderModel = new OrderSummaryModel();
            orderModel.Car = await _carService.GetAsync(id);
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(OrderSummaryModel orderModel)
        {
            if (ModelState.IsValid)
            {
                orderModel.Car = await _carService.GetAsync(orderModel.OrderRequestDto.CarId);
                orderModel.User = await _userService.GetAsync(_session.GetString("UserID"));
                orderModel.OrderRequestDto.PriceTotal = (orderModel.OrderRequestDto.ReturnDate - orderModel.OrderRequestDto.PickupDate).Days * orderModel.Car.RentPrice;
                //return RedirectToAction("OrderSummary");
                return View(orderModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderConfirmation(OrderSummaryModel orderModel)
        {
            await _orderService.AddAsync(orderModel.OrderRequestDto);
            var orderId = (await _orderService.GetAllUserOrdersAsync(_session.GetString("UserID"))).Last().Id;
            orderModel.OrderId = orderId;
            return View(orderModel);
        }
    }
}
