using System;

namespace ConsoleApp1.Devices
{
    public class ConnectionException : Exception
    {
        public ConnectionException() : base("Failed to connect to network.") { }
    }
}