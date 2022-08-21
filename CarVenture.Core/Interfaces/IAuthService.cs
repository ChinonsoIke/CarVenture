using System;
using System.Collections.Generic;
using System.Text;

namespace CarVenture.Core.Interfaces
{
    public interface IAuthService
    {
        public bool Login(string email, string password);
        public void Logout();
    }
}
