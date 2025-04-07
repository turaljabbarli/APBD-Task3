using ConsoleApp1.core;
using ConsoleApp1.interfaces;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1.Infrastructure
{
    /// <summary>
    /// Loads devices from a text file using a parser.
    /// </summary>
    public class FileDeviceLoader : IDeviceLoader
    {
        private readonly IDeviceParser _parser;

        public FileDeviceLoader(IDeviceParser parser)
        {
            _parser = parser;
        }

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
                    var device = _parser.Parse(line);
                    devices.Add(device);
                }
                catch
                {
                    
                }
            }

            return devices;
        }
    }
}