using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp1.Devices
{
    /// <summary>
    /// Manages a collection of electronic devices. Supports loading, adding, editing,
    /// removing, and saving devices to file. Limited to 15 devices.
    /// </summary>
    public class DeviceManager
    {
        private const int MaxDevices = 15;
        private readonly List<Device> _devices = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceManager"/> class and loads devices from the given loader.
        /// </summary>
        /// <param name="loader">The device loader implementation.</param>
        /// <param name="filePath">The path to the file containing devices to load.</param>
        public DeviceManager(IDeviceLoader loader, string filePath)
        {
            var loadedDevices = loader.LoadDevices(filePath);
            foreach (var device in loadedDevices)
            {
                if (_devices.Count >= MaxDevices)
                {
                    Console.WriteLine("Device storage full.");
                    break;
                }
                _devices.Add(device);
            }
        }

        /// <summary>
        /// Adds a new device to the manager.
        /// </summary>
        /// <param name="device">The device to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when storage is full.</exception>
        public void AddDevice(Device device)
        {
            if (_devices.Count >= MaxDevices)
                throw new InvalidOperationException("Storage full.");
            _devices.Add(device);
        }

        /// <summary>
        /// Removes a device with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the device to remove.</param>
        public void RemoveDevice(string id)
        {
            _devices.RemoveAll(d => d.Id == id);
        }

        /// <summary>
        /// Edits the name of a device by ID.
        /// </summary>
        /// <param name="id">The ID of the device to edit.</param>
        /// <param name="newName">The new name to assign.</param>
        public void EditDevice(string id, string newName)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
                device.Name = newName;
        }

        /// <summary>
        /// Turns on the device with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the device to turn on.</param>
        public void TurnOnDevice(string id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            device?.TurnOn();
        }

        /// <summary>
        /// Turns off the device with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the device to turn off.</param>
        public void TurnOffDevice(string id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            device?.TurnOff();
        }

        /// <summary>
        /// Displays all devices and their details in the console.
        /// </summary>
        public void ShowAllDevices()
        {
            foreach (var d in _devices)
                Console.WriteLine(d);
        }

        /// <summary>
        /// Saves all current devices to a file.
        /// </summary>
        /// <param name="path">The file path to save to.</param>
        public void SaveToFile(string path)
        {
            var lines = _devices.Select(d =>
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
