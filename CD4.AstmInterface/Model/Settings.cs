using System.ComponentModel;
using System.IO.Ports;

namespace CD4.AstmInterface.Model
{
    public class Settings
    {
        private Properties.Settings settings;
        public Settings()
        {
            settings = new Properties.Settings();

            ConnectionMode = (ConnectionMode)settings.ConnectionMode;
            ComPort = settings.ComPort;
            BaudRate = settings.BaudRate;
            DataBits = settings.DataBits;
            StopBits = (StopBits)settings.StopBits;
            parity = (Parity)settings.Parity;
            Handshake = (Handshake)settings.HandShake;
            IsSever = settings.IsServer;
            IpAddress = settings.IpAddress;
            Port = settings.Port;

            SerialPort = new SerialPort(ComPort);

            ExportBasepath = settings.ExportBasepath;
            Extension = settings.Extension;
            ControlExtension = settings.ControlExtension;
        }


        [Category("Operating Mode")]
        public ConnectionMode ConnectionMode { get; set; }

        #region Serial Settings
        [Browsable(false)]
        public SerialPort SerialPort { get; set; }
        [Category("Serial Settings")]
        public string ComPort { get; set; }
        [Category("Serial Settings")]
        public int BaudRate { get; set; }
        [Category("Serial Settings")]
        public int DataBits { get; set; }
        [Category("Serial Settings")]
        public StopBits StopBits { get; set; }
        [Category("Serial Settings")]
        public Parity parity { get; set; }
        [Category("Serial Settings")]
        public Handshake Handshake { get; set; }

        #endregion

        #region Ethernet Settings

        [Category("Ethernet Settings")]
        public bool IsSever { get; set; }
        [Category("Ethernet Settings")]
        public string IpAddress { get; set; }
        [Category("Ethernet Settings")]
        public int Port { get; set; }
        #endregion

        #region Export Settings

        [Category("Export Settings")]
        public string ExportBasepath { get; set; }
        [Category("Export Settings")]
        public string Extension { get; set; }
        [Category("Export Settings")]
        public string ControlExtension { get; set; }

        #endregion
    }
}
