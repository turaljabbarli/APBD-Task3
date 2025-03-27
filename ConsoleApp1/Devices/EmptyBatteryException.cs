using System;

namespace ConsoleApp1.Devices
{
    public class EmptyBatteryException : Exception
    {
        public EmptyBatteryException() : base("Battery too low to turn on the device.") { }
    }
}