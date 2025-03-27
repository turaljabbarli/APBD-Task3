namespace ConsoleApp1.core
{
    using ConsoleApp1.interfaces;
    using ConsoleApp1.Exceptions;
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents an embedded device with an IP address and network name.
    /// </summary>
    public class EmbeddedDevice : Device, INetworkConnectable
    {
        private string _ipAddress = "";

        /// <summary>
        /// Gets or sets the IP address of the device.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the network name.
        /// </summary>
        public string NetworkName { get; set; }

        /// <summary>
        /// Indicates whether the device is connected to the network.
        /// </summary>
        public bool IsConnected { get; private set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedDevice"/> class.
        /// </summary>
        /// <param name="id">The device ID.</param>
        /// <param name="name">The device name.</param>
        /// <param name="ipAddress">The device's IP address.</param>
        /// <param name="networkName">The device's network name.</param>
        public EmbeddedDevice(string id, string name, string ipAddress, string networkName)
            : base(id, name)
        {
            IpAddress = ipAddress;
            NetworkName = networkName;
        }

        /// <summary>
        /// Attempts to connect to a network. Throws if network name is invalid.
        /// </summary>
        /// <exception cref="ConnectionException">Thrown when network is invalid.</exception>
        public void Connect()
        {
            if (!NetworkName.Contains("MD Ltd."))
                throw new ConnectionException();

            IsConnected = true;
        }

        /// <summary>
        /// Turns on the device after successfully connecting to the network.
        /// </summary>
        public override void TurnOn()
        {
            Connect();
            base.TurnOn();
        }

        /// <summary>
        /// Returns a string representation of the embedded device.
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + $" | IP: {IpAddress} | Network: {NetworkName} | Connected: {IsConnected}";
        }

        private bool IsValidIp(string ip)
        {
            return Regex.IsMatch(ip, @"^(\d{1,3}\.){3}\d{1,3}$");
        }
    }
}
