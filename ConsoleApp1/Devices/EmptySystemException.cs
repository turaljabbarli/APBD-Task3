using System;

namespace ConsoleApp1.Devices
{
    public class EmptySystemException : Exception
    {
        public EmptySystemException() : base("Operating system is not installed.") { }
    }
}