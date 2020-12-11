using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IStaticDataDataAccess staticDataDataAccess;
        private readonly IMapper mapper;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;
        ResourceManager _resources;
        ResourceSet _resourceSet;

        public MainViewModel(IStaticDataDataAccess staticDataDataAccess, IMapper mapper, AuthorizeDetailEventArgs authorizeDetail)
        {
            _resources = new ResourceManager(typeof(Properties.Resources));
            _resourceSet = _resources.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

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

        public Image GetDisciplineImage(string imageName)
        {
            Bitmap disciplineIcon = null;
            foreach (DictionaryEntry entry in _resourceSet)
            {
                if ((string)entry.Key == imageName)
                {
                    disciplineIcon = (Bitmap)entry.Value;
                }
            }

            if (disciplineIcon is null)
            {
                return Properties.Resources.Disciplines;
            }
            else
            {
                return disciplineIcon;
            }
        }

        public int GetloggedInUserId()
        {
            return _authorizeDetail.UserId;
        }

        public async Task<List<ResultAlertModel>> GetResultAlertData()
        {
            try
            {
                var result = await staticDataDataAccess.GetResultAlertData();
                return mapper.Map<List<ResultAlertModel>>(result);
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
