using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AppRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] AppRoleDto roleDto)
        {
            var role = new AppRole { Name = roleDto.Name };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Rol başarıyla oluşturuldu.");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] AppRoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = roleDto.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return Ok("Rol başarıyla güncellendi.");
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return NoContent(); // 204 No Content
            }
            return BadRequest(result.Errors);
        }
    }
}