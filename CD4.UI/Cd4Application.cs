using CD4.DataLibrary.DataAccess;
using CD4.Entensibility.ReportingFramework;
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
        private readonly IReportsDataAccess _reportsDataAccess;
        private readonly IUserAuthEvaluator _userAuthEvaluator;
        private readonly ILoadMultipleExtensions _reportExtensions;

        public Cd4Application(IMainViewModel mainViewModel, IReportsDataAccess reportsDataAccess, IUserAuthEvaluator userAuthEvaluator, ILoadMultipleExtensions reportExtensions)
        {
            _mainViewModel = mainViewModel;
            _reportsDataAccess = reportsDataAccess;
            _userAuthEvaluator = userAuthEvaluator;
            _reportExtensions = reportExtensions;
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
                Application.Run(new MainView(_mainViewModel, _reportsDataAccess, _userAuthEvaluator, _reportExtensions) { Tag = "MainView" });
            }
            catch (Exception ex)
            {
                _log.Fatal(ex);
            }

        }
    }
}
