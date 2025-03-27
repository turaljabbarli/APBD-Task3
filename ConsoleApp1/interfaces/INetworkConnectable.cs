namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for devices that connect to a network.
    /// </summary>
    public interface INetworkConnectable
    {
        /// <summary>
        /// Attempts to connect the device to a network.
        /// </summary>
        void Connect();

        /// <summary>
        /// Gets a value indicating whether the device is connected.
        /// </summary>
        bool IsConnected { get; }
    }
}