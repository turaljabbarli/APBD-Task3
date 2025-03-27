using ConsoleApp1.core;

namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for parsing devices from text representations.
    /// </summary>
    public interface IDeviceParser
    {
        /// <summary>
        /// Parses a device from a line of text.
        /// </summary>
        /// <param name="line">A text line representing a device.</param>
        /// <returns>The parsed <see cref="Device"/> object.</returns>
        Device Parse(string line);
    }
}