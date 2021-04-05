using CD4.AstmInterface.Model;
using Essy.LIS.Connection;
using Essy.LIS.LIS02A2;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CD4.AstmInterface.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ILis01A2Connection lowLevelConnection;
        private Lis01A2Connection lisConnection;
        private LISParser lisParser;

        public MainViewModel()
        {
            Settings = new Settings();
            InitializeAstm();
        }

        private void InitializeAstm()
        {
            switch (Settings.ConnectionMode)
            {
                case ConnectionMode.Ethernet:
                    //Not implemented yet
                    throw new NotImplementedException("Ethernet connection not implemented!");
                    break;
                case ConnectionMode.Serial:
                    lowLevelConnection = new Lis01A02RS232Connection(Settings.SerialPort);
                    lisConnection = new Lis01A2Connection(lowLevelConnection);
                    lisParser = new LISParser(lisConnection);
                    
                    lisParser.OnSendProgress += LISParser_OnSendProgress; //Send data progress will trigger this event
                    lisParser.OnReceivedRecord += LISParser_OnReceivedRecord; //incoming LIS frames will trigger this event

                    lisParser.Connection.Connect();

                    break;
                default:
                    break;
            }
        }

        private void LISParser_OnReceivedRecord(object Sender, ReceiveRecordEventArgs e)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(e));
        }

        private void LISParser_OnSendProgress(object sender, SendProgressEventArgs e)
        {
            Debug.WriteLine("Send Progress: " + e.Progress);
        }

        public Settings Settings { get; set; }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
