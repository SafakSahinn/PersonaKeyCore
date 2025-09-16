using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeviceDto deviceDto)
        {
            var device = new Device
            {
                SerialNumber = deviceDto.SerialNumber,
                Location = deviceDto.Location,
                IsActive = true,
                DoorId = deviceDto.DoorId
            };
            await _deviceService.AddAsync(device);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _deviceService.GetAllAsync();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DeviceDto deviceDto)
        {
            var existingDevice = await _deviceService.GetByIdAsync(id);
            if (existingDevice == null)
            {
                return NotFound();
            }

            existingDevice.SerialNumber = deviceDto.SerialNumber;
            existingDevice.Location = deviceDto.Location;
            existingDevice.DoorId = deviceDto.DoorId;

            await _deviceService.UpdateAsync(existingDevice);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            await _deviceService.DeleteAsync(device);
            return NoContent();
        }
    }
}