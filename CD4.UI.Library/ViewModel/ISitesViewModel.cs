using CD4.UI.Library.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface ISitesViewModel
    {
        SitesModel SelectedRow { get; set; }
        BindingList<SitesModel> SiteList { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedSiteData(int selectedId);
        void SaveSite(object sender, EventArgs e);
    }
}