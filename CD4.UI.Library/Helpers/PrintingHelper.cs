using CD4.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Helpers
{
    public class PrintingHelper : IPrintingHelper
    {
        #region Private Properties
        private readonly IStaticDataDataAccess _staticData;

        #endregion

        #region Event Declarations
        private event EventHandler InitializeStaticData;
        #endregion

        #region Default Constructor
        public PrintingHelper(IStaticDataDataAccess staticDataDataAccess)
        {
            _staticData = staticDataDataAccess;
            InitializeStaticData += PrintingHelper_InitializeStaticData;
            InitializeStaticData?.Invoke(this, EventArgs.Empty);

        }

        #endregion

        #region Public Properties
        public string BarcodePrinterName { get; set; }

        #endregion

        #region Private Methods
        private async void PrintingHelper_InitializeStaticData(object sender, EventArgs e)
        {
            try
            {
                await InitializePrintingRequirementsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task InitializePrintingRequirementsAsync()
        {
            //Set the default printer name as BarcodePrinter
            BarcodePrinterName = "BarcodePrinter";
            //Fetch the workstation name
            var workstationName = GetWorkStationName();
            //call datalayer to get all the printers with their types (Barcode printer, document printer... etc)
            var workStationPrinters = await _staticData.GetWorkStationPrintersAsync(workstationName);
            var barcodePrinter = workStationPrinters.Find((x) => x.PrinterType == 1);
            if (barcodePrinter != null) BarcodePrinterName = barcodePrinter.PrinterName;
        }


        /// <summary>
        /// Returns workstation Name
        /// </summary>
        /// <returns>A string of workstation name</returns>
        private string GetWorkStationName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message + "\n" + ex.StackTrace);
                throw new Exception("Cannot get the FQDN(Fully Qualified Domain Name) / workstation name");
            }
        }
        #endregion

    }
}
