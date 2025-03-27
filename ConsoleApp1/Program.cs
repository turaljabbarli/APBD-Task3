using ConsoleApp1.Logic;
using ConsoleApp1.Infrastructure;
using ConsoleApp1.interfaces;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Working dir: " + Directory.GetCurrentDirectory());

            IDeviceParser parser = new TxtDeviceParser();
            IDeviceStorage storage = new FileDeviceStorage(parser);

            var manager = new DeviceManager(storage.LoadDevices("devices.txt"));

            manager.ShowAllDevices();

            manager.TurnOnDevice("SW001");
            manager.EditDevice("PC001", "Office Laptop");

            storage.SaveDevices("devices_updated.txt", manager.GetAllDevices());
        }
    }
}