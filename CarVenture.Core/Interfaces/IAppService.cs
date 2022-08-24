using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Interfaces
{
    public interface IAppService
    {
        public bool DBLoaded { get; set; }

        /// <summary>
        /// Retrieves all database items stored in JSON files and stores them in objects in the datastore
        /// </summary>
        /// <returns></returns>
        public Task LoadDB();
    }
}
