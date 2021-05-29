using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Helpers
{
    public class GlobalSettingsHelper : IGlobalSettingsHelper
    {
        private readonly IGlobalSettingsDataAccess _globalSettingsDataAccess;

        private event EventHandler InitializeGlobalSettings;
        public GlobalSettingsHelper(IGlobalSettingsDataAccess globalSettingsDataAccess)
        {
            Settings = new GlobalSettingsModel();
            _globalSettingsDataAccess = globalSettingsDataAccess;
            InitializeGlobalSettings += GlobalSettingsHelper_OnInitializeGlobalSettings;

            InitializeGlobalSettings?.Invoke(this, EventArgs.Empty);
        }

        private async void GlobalSettingsHelper_OnInitializeGlobalSettings(object sender, EventArgs e)
        {
            try
            {
                var settings = await _globalSettingsDataAccess.ReadAllGlobalSettingsAsync();
                Settings = new GlobalSettingsModel() 
                {
                    VerifyNidPpOnOrder = settings.VerifyNidPpOnOrder,
                    IsAnalysisRequestBarcodeRequired = settings.IsAnalysisRequestBarcodeRequired,
                    ReportExportBasePath = settings.ReportExportBasePath,
                    IsFullnameAbbreviated = settings.IsFullnameAbbreviated,
                    HmsLinkQuery = settings.HmsLinkQuery
                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        public GlobalSettingsModel Settings { get; set; }
    }
}
