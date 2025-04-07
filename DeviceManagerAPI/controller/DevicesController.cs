using ConsoleApp1.core;
using ConsoleApp1.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DeviceManagerAPI.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceManager _manager;

        public DevicesController(DeviceManager manager)
        {
            _manager = manager;
        }

        // GET: api/devices
        [HttpGet]
        public IActionResult GetDevices()
        {
            var devices = _manager.GetAllDevices();
            return Ok(devices);
        }

        // GET: api/devices/{id}
        [HttpGet("{id}")]
        public IActionResult GetDeviceById(string id)
        {
            var device = _manager.GetAllDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
                return NotFound();
            return Ok(device);
        }

        // POST: api/devices
        [HttpPost]
        public IActionResult AddDevice([FromBody] Device device)
        {
            if (device == null)
                return BadRequest("Device is null.");

            try
            {
                _manager.AddDevice(device);
                return CreatedAtAction(nameof(GetDeviceById), new { id = device.Id }, device);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // handles "Storage full" exception
            }
        }

        // PUT: api/devices/{id}
        [HttpPut("{id}")]
        public IActionResult RenameDevice(string id, [FromBody] string newName)
        {
            var existingDevice = _manager.GetAllDevices().FirstOrDefault(d => d.Id == id);
            if (existingDevice == null)
                return NotFound();

            _manager.EditDevice(id, newName);
            return Ok($"Device {id} renamed to {newName}.");
        }

        // DELETE: api/devices/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(string id)
        {
            var device = _manager.GetAllDevices().FirstOrDefault(d => d.Id == id);
            if (device == null)
                return NotFound();

            _manager.RemoveDevice(id);
            return NoContent();
        }
    }
}
