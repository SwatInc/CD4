using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class SitesViewModel : INotifyPropertyChanged, ISitesViewModel
    {
        private readonly IStaticDataDataAccess _staticDataDataAccess;
        private readonly IMapper _mapper;

        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;
        public event EventHandler LoadAllSites;


        public SitesViewModel(IStaticDataDataAccess staticDataDataAccess, IMapper mapper)
        {
            this.SiteList = new BindingList<SitesModel>();
            this.SelectedRow = new SitesModel();

            //InitializeDemoData();
            _staticDataDataAccess = staticDataDataAccess;
            _mapper = mapper;
            LoadAllSites += SitesViewModel_LoadAllSites;
            LoadAllSites?.Invoke(this, EventArgs.Empty);
        }

        private async void SitesViewModel_LoadAllSites(object sender, EventArgs e)
        {
            try
            {
                var sitesData = await _staticDataDataAccess.LoadAllSites();
                var mappedSites = _mapper.Map<List<SitesModel>>(sitesData);
                SiteList.Clear();
                foreach (var site in mappedSites)
                {
                    SiteList.Add(site);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InitializeDemoData()
        {
            var site1 = new SitesModel() { Id = 1, Site = "IGMH" };
            var site2 = new SitesModel() { Id = 2, Site = "FARUKOLHU" };

            this.SiteList.Add(site1);
            this.SiteList.Add(site2);
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        public BindingList<SitesModel> SiteList { get; set; }
        public SitesModel SelectedRow { get; set; }

        public void DisplaySelectedSiteData(int selectedId)
        {
            var selectedRow = this.SiteList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.Site = selectedRow.Site;
        }

        public async void SaveSite(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRow.Site))
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.Site))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.Site} is already in the system");
                return;
            }

            try
            {
                var sitesModel = await _staticDataDataAccess.AddSite(SelectedRow.Site);
                var mappedSitesModel = _mapper.Map<SitesModel>(sitesModel);
                PushingMessages?.Invoke(this, $"{SelectedRow.Site} is saved.");
            }
            catch (Exception)
            {

                throw;
            }


        }

        private bool IsDublicatedSubmitted(string site)
        {
            var Search = SiteList.SingleOrDefault(p => p.Site == site);
            if (Search is null) return false;
            return true;
        }
    }
}
