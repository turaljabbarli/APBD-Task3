namespace ConsoleApp1.Exceptions
{
    using System;

    public class EmptySystemException : Exception
    {
        public EmptySystemException() : base("Operating system is not installed.") { }
    }
}