using ConsoleApp1.core;
using ConsoleApp1.interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1.Infrastructure
{
    public class FileDeviceStorage : IDeviceStorage
    {
        private readonly IDeviceParser _parser;

        public FileDeviceStorage(IDeviceParser parser)
        {
            _parser = parser;
        }

        public List<Device> LoadDevices(string path)
        {
            var devices = new List<Device>();
            if (!File.Exists(path))
                return devices;

            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                try
                {
                    devices.Add(_parser.Parse(line));
                }
                catch
                {
                    
                }
            }

            return devices;
        }

        public void SaveDevices(string path, IEnumerable<Device> devices)
        {
            var lines = devices.Select(d =>
            {
                return d switch
                {
                    Smartwatch sw => $"SW;{sw.Id};{sw.Name};{sw.BatteryPercentage}",
                    PersonalComputer pc => $"P;{pc.Id};{pc.Name};{pc.OperatingSystem}",
                    EmbeddedDevice ed => $"ED;{ed.Id};{ed.Name};{ed.IpAddress};{ed.NetworkName}",
                    _ => ""
                };
            });

            File.WriteAllLines(path, lines);
        }
    }
}