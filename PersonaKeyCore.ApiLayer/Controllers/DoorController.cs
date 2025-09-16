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
    public class DoorController : ControllerBase
    {
        private readonly IDoorService _doorService;

        public DoorController(IDoorService doorService)
        {
            _doorService = doorService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoorDto doorDto)
        {
            var door = new Door { Name = doorDto.Name, Location = doorDto.Location, IsActive = doorDto.IsActive };
            await _doorService.AddAsync(door);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doors = await _doorService.GetAllAsync();
            return Ok(doors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var door = await _doorService.GetByIdAsync(id);
            if (door == null)
            {
                return NotFound();
            }
            return Ok(door);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoorDto doorDto)
        {
            var existingDoor = await _doorService.GetByIdAsync(id);
            if (existingDoor == null)
            {
                return NotFound();
            }

            existingDoor.Name = doorDto.Name;
            existingDoor.Location = doorDto.Location;
            existingDoor.IsActive = doorDto.IsActive;

            await _doorService.UpdateAsync(existingDoor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var door = await _doorService.GetByIdAsync(id);
            if (door == null)
            {
                return NotFound();
            }

            await _doorService.DeleteAsync(door);
            return NoContent();
        }
    }
}