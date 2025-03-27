namespace ConsoleApp1.Exceptions
{
    using System;

    public class EmptyBatteryException : Exception
    {
        public EmptyBatteryException() : base("Battery too low to turn on the device.") { }
    }
}