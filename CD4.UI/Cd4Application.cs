﻿using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.ViewModel;
using CD4.UI.View;
using DevExpress.UserSkins;
using DevExpress.XtraReports;
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
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly IReportsDataAccess reportsDataAccess;

        public Cd4Application(IMainViewModel mainViewModel, IReportsDataAccess reportsDataAccess)
        {
            _mainViewModel = mainViewModel;
            this.reportsDataAccess = reportsDataAccess;
        }

        private IMainViewModel _mainViewModel { get; }

        public void Run()
        {
            _log.Info("Application startup.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            Application.Run(new MainView(_mainViewModel, reportsDataAccess));

        }
    }
}
