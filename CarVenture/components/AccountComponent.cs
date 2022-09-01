using CarVenture.Core.Interfaces;
using CarVenture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CarVenture.components
{
    public class AccountComponent : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly ISession _session;

        public AccountComponent(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _session = httpContextAccessor.HttpContext.Session;
        }
        public IViewComponentResult Invoke()
        {
            var dashboardModel = new DashboardModel();
            
            dashboardModel.User = _userService.GetAsync(_session.GetString("UserID")).Result;
            return View(dashboardModel);
        }
    }
}
