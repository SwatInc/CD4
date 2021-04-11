using CD4.DataLibrary.DataAccess;
using CD4.DataLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.GrpcService.Services
{
    public class BillingCD4TestMapService : IBillingCD4TestMapService
    {
        private readonly IStaticDataDataAccess _staticDataDataAccess;
        private readonly ILogger _logger;

        public BillingCD4TestMapService(IStaticDataDataAccess staticDataDataAccess, ILogger<BillingCD4TestMapService> logger)
        {
            TestMap = new List<BillingTestMappingModel>();
            _staticDataDataAccess = staticDataDataAccess;
            _logger = logger;
        }

        private async Task InitializeMap(object sender, EventArgs e)
        {
            _logger.LogDebug("Initializing Test map");
            try
            {
                TestMap.Clear();
                TestMap.AddRange(await _staticDataDataAccess.GetBillingTestCodeMappings());
                _logger.LogInformation($"Test map load successful.\n{JsonConvert.SerializeObject(TestMap, Formatting.Indented)}");
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"failed loading test map. \n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private List<BillingTestMappingModel> TestMap { get; set; }

        public List<BillingTestMappingModel> GetTestMap()
        {
            if (TestMap.Count > 0) {return TestMap;}

            InitializeMap(this, EventArgs.Empty).GetAwaiter().GetResult();
            return TestMap;
        }
    }
}
