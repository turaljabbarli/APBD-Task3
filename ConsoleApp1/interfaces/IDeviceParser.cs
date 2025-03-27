using ConsoleApp1.core;

namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for parsing devices from a line of text.
    /// </summary>
    public interface IDeviceParser
    {
        /// <summary>
        /// Parses a device from a string line.
        /// </summary>
        /// <param name="line">The input line.</param>
        /// <returns>A Device object parsed from the line.</returns>
        Device Parse(string line);
    }
}