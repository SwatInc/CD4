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
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        public MainViewModel(IStaticDataDataAccess staticDataDataAccess, IMapper mapper, AuthorizeDetailEventArgs authorizeDetail)
        {
            this.staticDataDataAccess = staticDataDataAccess;
            this.mapper = mapper;
            _authorizeDetail = authorizeDetail;
        }

        public async Task<List<WorkStationPrintersInfoModel>> GetApplicationWideStaticData()
        {
            //Get the workstation name
            var workstation = GetWorkStationName();
            try
            {
                //request for data
                var output = await staticDataDataAccess.GetWorkStationPrintersAsync(workstation);
                //map the output to local model and return
                return mapper.Map<List<WorkStationPrintersInfoModel>>(output);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetloggedInUserId()
        {
            return _authorizeDetail.UserId;
        }

        private string GetWorkStationName()
        {
            return Environment.MachineName;
        }
    }
}
