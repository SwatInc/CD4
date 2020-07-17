using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IStaticDataDataAccess staticDataDataAccess;
        private readonly IMapper mapper;

        public MainViewModel(IStaticDataDataAccess staticDataDataAccess, IMapper mapper)
        {
            this.staticDataDataAccess = staticDataDataAccess;
            this.mapper = mapper;
        }

        public async Task<List<WorkStationPrintersInfo>> GetApplicationWideStaticData()
        {
            //Get the workstation name
            var workstation = GetWorkStationName();
            try
            {
                //request for data
                var output = await staticDataDataAccess.GetWorkStationPrintersAsync(workstation);
                //map the output to local model and return
                var map =  mapper.Map<List<WorkStationPrintersInfo>>(output);
                return map;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GetWorkStationName()
        {
            return Environment.MachineName;
        }
    }
}
