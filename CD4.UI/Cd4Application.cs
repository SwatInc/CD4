using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.ViewModel;
using CD4.UI.View;
using DevExpress.UserSkins;
using System;
using System.Windows.Forms;

namespace CD4.UI
{

    public class Cd4Application : ICd4Application
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly IReportsDataAccess reportsDataAccess;
        private readonly IUserAuthEvaluator _userAuthEvaluator;

        public Cd4Application(IMainViewModel mainViewModel, IReportsDataAccess reportsDataAccess, IUserAuthEvaluator userAuthEvaluator)
        {
            _mainViewModel = mainViewModel;
            this.reportsDataAccess = reportsDataAccess;
            _userAuthEvaluator = userAuthEvaluator;
        }

        private IMainViewModel _mainViewModel { get; }

        public void Run()
        {
            _log.Info("Application startup.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                BonusSkins.Register();
                Application.Run(new MainView(_mainViewModel, reportsDataAccess, _userAuthEvaluator) { Tag = "MainView" });

            }
            catch (Exception ex)
            {
                _log.Fatal(ex);
            }

        }
    }
}
