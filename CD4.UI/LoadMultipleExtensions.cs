using CD4.Entensibility.ReportingFramework;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CD4.UI
{
    internal class LoadMultipleExtensions : ILoadMultipleExtensions
    {
        public LoadMultipleExtensions()
        {
            ReportTemplates = new List<IFetchReportTemplate>();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                var reportTypes = Directory.EnumerateFiles(Environment.CurrentDirectory)
                    .Where(filename => filename.EndsWith(".dll"))
                    .Select(filepath => Assembly.LoadFrom(filepath))
                    .SelectMany(assembly => assembly.GetTypes()
                    .Where(type => typeof(IFetchReportTemplate).IsAssignableFrom(type) && type.IsClass));

                
                foreach (var type in reportTypes)
                {
                    var instance = Activator.CreateInstance(type) as IFetchReportTemplate;
                    ReportTemplates.Add(instance);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading analysis report extensions. Please find the error message below\n{ex.Message}");
            }

        }

        public List<IFetchReportTemplate> ReportTemplates { get; set; }

    }
}