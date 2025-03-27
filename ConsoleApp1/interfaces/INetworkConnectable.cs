namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for devices that connect to a network.
    /// </summary>
    public interface INetworkConnectable
    {
        /// <summary>Attempts to connect to a network.</summary>
        void Connect();

        /// <summary>Indicates whether the device is connected.</summary>
        bool IsConnected { get; }
    }
}