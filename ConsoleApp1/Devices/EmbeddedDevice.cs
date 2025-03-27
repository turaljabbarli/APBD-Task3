using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Devices
{
    /// <summary>
    /// Represents an embedded device with an IP address and network name.
    /// </summary>
    public class EmbeddedDevice : Device, INetworkConnectable
    {
        private string _ipAddress = "";

        /// <summary>Gets or sets the IP address of the device.</summary>
        /// <exception cref="ArgumentException">Thrown if IP format is invalid.</exception>
        public string IpAddress
        {
            get => _ipAddress;
            set
            {
                if (!IsValidIp(value))
                    throw new ArgumentException("Invalid IP address format.");
                _ipAddress = value;
            }
        }

        /// <summary>Gets or sets the network name.</summary>
        public string NetworkName { get; set; }

        /// <summary>Initializes a new <see cref="EmbeddedDevice"/> with IP and network.</summary>
        public EmbeddedDevice(string id, string name, string ipAddress, string networkName)
            : base(id, name)
        {
            IpAddress = ipAddress;
            NetworkName = networkName;
        }

        /// <summary>Attempts to connect to the network. Throws if invalid network.</summary>
        public void Connect()
        {
            if (!NetworkName.Contains("MD Ltd."))
                throw new ConnectionException();
        }

        /// <summary>Turns on the device after attempting to connect to the network.</summary>
        public override void TurnOn()
        {
            Connect();
            base.TurnOn();
        }

        /// <summary>Returns a string representation of the embedded device.</summary>
        public override string ToString()
        {
            return base.ToString() + $" | IP: {IpAddress} | Network: {NetworkName}";
        }

        private bool IsValidIp(string ip)
        {
            return Regex.IsMatch(ip, @"^(\d{1,3}\.){3}\d{1,3}$");
        }
    }
}