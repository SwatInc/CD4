using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using CD4.UI.View;
using CD4.UI.Library.ViewModel;
using Autofac;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch =true)]
namespace CD4.UI
{
    static class Program
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                _log.Info("Initialize dependency injection system.");
                var container = ContainerConfig.Configure();

                using var scope = container.BeginLifetimeScope();
                var app = scope.Resolve<ICd4Application>();
                FormFactory.Use(container.Resolve<IFormFactory>());

                app.Run();
            }
            catch (Exception ex)
            {
                _log.Fatal(ex.Message + "\n", ex);

                //handle any inner exceptions
                var inner = ex.InnerException;

                while (inner != null)
                {
                    _log.Fatal($"Inner Stack Trace\n{inner.Message}\n{inner.StackTrace}");
                }
            }

            
        }
    }
}
