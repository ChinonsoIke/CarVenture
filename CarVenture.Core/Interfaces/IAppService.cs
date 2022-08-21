using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Interfaces
{
    public interface IAppService
    {
        public bool DBLoaded { get; set; }
        public Task LoadDB();
    }
}
