using System.Collections.Generic;
using ConsoleApp1.core;

namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for classes that load devices from a data source (e.g., a file).
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