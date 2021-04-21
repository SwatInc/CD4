using System;
using System.ComponentModel;
using System.IO.Ports;

namespace CD4.AstmInterface.Model
{
    public class Settings
    {
        private Properties.Settings settings;
        private string driverPath;

        public Settings()
        {
            settings = new Properties.Settings();
            SerialPort = new SerialPort(ComPort);
        }


        [Category("Operating Mode")]
        public ConnectionMode ConnectionMode
        {
            get => (ConnectionMode)settings.ConnectionMode;
            set => settings.ConnectionMode = Convert.ToInt32(value);
        }

        #region Serial Settings
        [Browsable(false)]
        public SerialPort SerialPort { get; set; }
        [Category("Serial Settings")]
        public string ComPort
        {
            get => settings.ComPort;
            set => settings.ComPort = value;
        }

        internal void Save()
        {
            settings.Save();
        }

        [Category("Serial Settings")]
        public int BaudRate
        {
            get => settings.BaudRate;
            set => settings.BaudRate = value;
        }
        [Category("Serial Settings")]
        public int DataBits
        {
            get => settings.DataBits;
            set => settings.DataBits = value;
        }
        [Category("Serial Settings")]
        public StopBits StopBits
        {
            get => (StopBits)settings.StopBits;
            set => settings.StopBits = Convert.ToInt32(value);
        }
        [Category("Serial Settings")]
        public Parity Parity
        {
            get => (Parity)settings.Parity;
            set => settings.Parity = Convert.ToInt32(value);
        }
        [Category("Serial Settings")]
        public Handshake Handshake
        {
            get => (Handshake)settings.HandShake;
            set => settings.HandShake = Convert.ToInt32(value);
        }

        #endregion

        #region Ethernet Settings

        [Category("Ethernet Settings")]
        public bool IsSever
        {
            get => settings.IsServer;
            set => settings.IsServer = value;
        }
        [Category("Ethernet Settings")]
        public string IpAddress
        {
            get => settings.IpAddress;
            set => settings.IpAddress = value;
        }
        [Category("Ethernet Settings")]
        public int Port
        {
            get => settings.Port;
            set => settings.Port = value;
        }
        #endregion

        #region Export Settings

        [Category("Export Settings")]
        public string ExportBasepath
        {
            get => settings.ExportBasepath;
            set => settings.ExportBasepath = value;
        }
        [Category("Export Settings")]
        public string Extension
        {
            get => settings.Extension;
            set => settings.Extension = value;
        }
        [Category("Export Settings")]
        public string ControlExtension
        {
            get => settings.ControlExtension;
            set => settings.ControlExtension = value;
        }

        #endregion

        #region Rules Engine
        [Category("Rules Engine")]
        public string AnalyserName 
        {
            get => settings.AnalyserName;
            set => settings.AnalyserName = value;
        }
        #endregion
    }
}
