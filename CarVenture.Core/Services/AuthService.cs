using CarVenture.Core.Interfaces;
using CarVenture.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISession _session;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _userRepository = userRepository;
            _logger = logger;
        }

        public bool Login(string email, string password)
        {
            var user = _userRepository.Get(email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return false;
            }

            _session.SetString("UserID", user.Id);
            _logger.LogInformation($"User login: {user.Id}");

            return true;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
