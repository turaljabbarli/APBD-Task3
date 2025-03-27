﻿using ConsoleApp1.interfaces;
using ConsoleApp1.Infrastructure;

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
            IDeviceLoader loader = new FileDeviceLoader(parser);
            return new DeviceManager(loader, filePath);
        }
    }
}