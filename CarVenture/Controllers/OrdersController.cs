using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public IActionResult Index(string id)
        {
            if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

            var orderModel = new OrderSummaryModel();
            orderModel.Car = _carService.Get(id);
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(OrderSummaryModel orderModel)
        {
            if (ModelState.IsValid)
            {
                orderModel.Car = _carService.Get(orderModel.OrderRequestDto.CarId);
                orderModel.User = _userService.Get(_session.GetString("UserID"));
                orderModel.OrderRequestDto.PriceTotal = (orderModel.OrderRequestDto.ReturnDate - orderModel.OrderRequestDto.PickupDate).Days * orderModel.Car.RentPrice;
                //return RedirectToAction("OrderSummary");
                return View(orderModel);
            }

            return RedirectToAction("Index");
        }

        //public IActionResult OrderSummary(OrderSummaryModel orderModel)
        //{
        //    if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

        //    return View(orderModel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderConfirmation(OrderSummaryModel orderModel)
        {
            _orderService.AddAsync(orderModel.OrderRequestDto);
            var orderId = _orderService.GetAllUserOrders(_session.GetString("UserID")).Last().Id;
            orderModel.OrderId = orderId;
            return View(orderModel);
        }

        //public IActionResult OrderConfirmation()
        //{
        //    if (_session.GetString("UserID") == null) return RedirectToAction("Login", "Auth");

        //    var orderId = _orderService.GetAllUserOrders(_session.GetString("UserID")).Last().Id;

        //    return View(orderId);
        //}
    }
}
