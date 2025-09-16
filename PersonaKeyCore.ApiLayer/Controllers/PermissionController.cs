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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PermissionDto permissionDto)
        {
            var permission = new Permission
            {
                RoleId = permissionDto.RoleId,
                DoorId = permissionDto.DoorId
            };
            await _permissionService.AddAsync(permission);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissions = await _permissionService.GetAllAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _permissionService.GetByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PermissionDto permissionDto)
        {
            var existingPermission = await _permissionService.GetByIdAsync(id);
            if (existingPermission == null)
            {
                return NotFound();
            }

            existingPermission.RoleId = permissionDto.RoleId;
            existingPermission.DoorId = permissionDto.DoorId;

            await _permissionService.UpdateAsync(existingPermission);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _permissionService.GetByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            await _permissionService.DeleteAsync(permission);
            return NoContent();
        }
    }
}