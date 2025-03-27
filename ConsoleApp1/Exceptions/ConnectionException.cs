namespace ConsoleApp1.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException() : base("Failed to connect to network.") { }
    }
}