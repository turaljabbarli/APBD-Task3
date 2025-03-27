using ConsoleApp1.core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Logic
{
    /// <summary>
    /// Manages a collection of electronic devices. Provides operations such as add, edit, remove, power control, and retrieval.
    /// </summary>
    public class DeviceManager
    {
        private const int MaxDevices = 15;
        private readonly List<Device> _devices = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceManager"/> class with an optional collection of devices.
        /// </summary>
        /// <param name="initialDevices">The initial devices to add.</param>
        public DeviceManager(IEnumerable<Device> initialDevices)
        {
            _devices.AddRange(initialDevices.Take(MaxDevices));
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
        /// Returns all currently managed devices.
        /// </summary>
        /// <returns>An enumerable of all devices.</returns>
        public IEnumerable<Device> GetAllDevices() => _devices;
    }
}
