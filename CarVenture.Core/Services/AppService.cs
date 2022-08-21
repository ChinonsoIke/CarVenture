using CarVenture.Core.Interfaces;
using CarVenture.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarVenture.Core.Services
{
    public class AppService : IAppService
    {
        private readonly ILogger<AppService> _logger;

        public AppService(ILogger<AppService> logger)
        {
            _logger = logger;
        }
        public bool DBLoaded { get; set; }

        public async Task LoadDB()
        {
            try
            {
                await DataStore.LoadDatabaseAsync();
                DBLoaded = true;

                _logger.LogInformation("Successfully loaded database.");
            }
            catch (Exception)
            {
                _logger.LogError("Could not load database.");
                return;
            }
        }
    }
}
