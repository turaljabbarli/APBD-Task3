using ConsoleApp1.interfaces;
using ConsoleApp1.Infrastructure;
using ConsoleApp1.core;

namespace ConsoleApp1.Logic
{
    /// <summary>
    /// Factory class for creating DeviceManager instances with proper dependencies.
    /// </summary>
    public static class DeviceManagerFactory
    {
        public static DeviceManager Create(string filePath)
        {
            IDeviceParser parser = new TxtDeviceParser();
            IDeviceStorage storage = new FileDeviceStorage(parser);
            var devices = storage.LoadDevices(filePath);

            return new DeviceManager(devices);
        }
    }
}