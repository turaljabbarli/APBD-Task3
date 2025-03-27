using System.Collections.Generic;
using ConsoleApp1.core;

namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for saving and loading devices from persistent storage.
    /// </summary>
    public interface IDeviceStorage
    {
        /// <summary>
        /// Loads a list of devices from the given path.
        /// </summary>
        /// <param name="path">The file path to read from.</param>
        /// <returns>A list of loaded <see cref="Device"/> objects.</returns>
        List<Device> LoadDevices(string path);

        /// <summary>
        /// Saves a list of devices to the given path.
        /// </summary>
        /// <param name="path">The file path to write to.</param>
        /// <param name="devices">The devices to save.</param>
        void SaveDevices(string path, IEnumerable<Device> devices);
    }
}