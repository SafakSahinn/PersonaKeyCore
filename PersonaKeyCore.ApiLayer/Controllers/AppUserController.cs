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
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AppUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser
            {
                Email = userDto.Email,
                UserName = userDto.UserName
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla kaydedildi.");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] AppUserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = userDto.Email;
            user.UserName = userDto.UserName;
            // Şifre güncelleme için ayrı bir metot kullanılmalıdır

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı bilgileri başarıyla güncellendi.");
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return NoContent(); // 204 No Content
            }
            return BadRequest(result.Errors);
        }
    }
}