namespace ConsoleApp1.Devices
{
    /// <summary>
    /// Interface for devices that connect to a network.
    /// </summary>
    public interface INetworkConnectable
    {
        /// <summary>Attempts to connect to a network.</summary>
        void Connect();
    }
}