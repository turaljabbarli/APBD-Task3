using ConsoleApp1.core;
using ConsoleApp1.interfaces;

namespace ConsoleApp1.Infrastructure
{
    /// <summary>
    /// Parses device data from text lines in a predefined format.
    /// </summary>
    public class TxtDeviceParser : IDeviceParser
    {
        public Device Parse(string line)
        {
            var parts = line.Split(';', StringSplitOptions.TrimEntries);
            if (parts.Length < 3) throw new FormatException("Line too short");

            string typeCode = parts[0];
            string id = parts[1];
            string name = parts[2];

            return typeCode switch
            {
                "SW" when parts.Length == 4 && int.TryParse(parts[3], out int battery) =>
                    new Smartwatch(id, name, battery),

                "P" => new PersonalComputer(id, name, parts.Length > 3 ? parts[3] : null),

                "ED" when parts.Length == 5 =>
                    new EmbeddedDevice(id, name, parts[3], parts[4]),

                _ => throw new FormatException("Invalid device type or data")
            };
        }
    }
}