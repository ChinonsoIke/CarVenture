using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Login(string email, string password);
        public void Logout();
    }
}
