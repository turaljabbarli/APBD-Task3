using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1.Devices
{
    public class FileDeviceLoader : IDeviceLoader
    {
        public List<Device> LoadDevices(string filePath)
        {
            var devices = new List<Device>();

            if (!File.Exists(filePath))
                return devices;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                try
                {
                    var device = ParseLine(line);
                    if (device != null)
                        devices.Add(device);
                }
                catch
                {
                    // Skip bad line
                }
            }

            return devices;
        }

        private Device? ParseLine(string line)
        {
            var parts = line.Split(';', StringSplitOptions.TrimEntries);
            if (parts.Length < 3) return null;

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

                _ => null
            };
        }
    }
}