using System.ComponentModel.DataAnnotations;

namespace PersonaKeyCore.ApiLayer.Dtos
{
    public class AppUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}