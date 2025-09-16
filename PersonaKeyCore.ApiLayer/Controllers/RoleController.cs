using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.ApiLayer.DTOs;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleDto roleDto)
        {
            var role = new Role { Name = roleDto.Name };
            await _roleService.AddAsync(role);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDto roleDto)
        {
            var existingRole = await _roleService.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = roleDto.Name;
            await _roleService.UpdateAsync(existingRole);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteAsync(role);
            return NoContent(); // 204 No Content
        }
    }
}