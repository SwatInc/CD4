using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.AstmInterface.Model
{
    public class Settings
    {

        public Settings()
        {
            var settings = new Properties.Settings();

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
        }

        public ConnectionMode ConnectionMode { get; set; }

        #region Serial Settings
        public SerialPort SerialPort { get; set; }
        public string ComPort { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public Parity parity { get; set; }
        public Handshake Handshake { get; set; }
        #endregion

        #region Ethernet Settings
        public bool IsSever { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        #endregion

    }
}
