using CD4.UI.Library.ViewModel;
using CD4.UI.View;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI
{
    public class Cd4Application :ICd4Application
    {
        public Cd4Application(IMainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public IMainViewModel _mainViewModel { get; }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            Application.Run(new MainView(_mainViewModel));

        }
    }
}
