using CD4.DataLibrary.DataAccess;
using CD4.Entensibility.ReportingFramework;
using CD4.UI.Library.Helpers;
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
        private readonly IGlobalSettingsHelper _globalSettingsHelper;
        private readonly ILoadMultipleExtensions _reportExtensions;

        public Cd4Application(IMainViewModel mainViewModel, 
            IReportsDataAccess reportsDataAccess, 
            IUserAuthEvaluator userAuthEvaluator, 
            IGlobalSettingsHelper globalSettingsHelper,
            ILoadMultipleExtensions reportExtensions)
        {
            _mainViewModel = mainViewModel;
            _reportsDataAccess = reportsDataAccess;
            _userAuthEvaluator = userAuthEvaluator;
            _globalSettingsHelper = globalSettingsHelper;
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
                Application.Run(new MainView(_mainViewModel, _reportsDataAccess, _userAuthEvaluator,_globalSettingsHelper, _reportExtensions) { Tag = "MainView" });
            }
            catch (Exception ex)
            {
                
                _log.Fatal(ex.Message + "\n", ex);

                MessageBox.Show($"{ex.Message}\n{ex}");

                //handle any inner exceptions
                var inner = ex.InnerException;
                var errorMessage = "Inner Stack Trace\n-------------------------\n";

                while (inner != null)
                {
                    _log.Fatal($"Inner Stack Trace\n{inner.Message}\n{inner.StackTrace}");
                    errorMessage = $"{errorMessage}\n{inner.Message}\n{inner.StackTrace}";
                    //get the next inner exception for next iteration
                    inner = inner.InnerException;
                }

                MessageBox.Show(errorMessage);
            }

        }
    }
}
