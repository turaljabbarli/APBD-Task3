using System.Collections.Generic;

namespace ConsoleApp1.Devices
{
    /// <summary>
    /// Interface for classes that load devices from a data source (e.g., file).
    /// </summary>
    public interface IDeviceLoader
    {
        /// <summary>
        /// Loads devices from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the data file.</param>
        /// <returns>A list of loaded devices.</returns>
        List<Device> LoadDevices(string filePath);
    }
}