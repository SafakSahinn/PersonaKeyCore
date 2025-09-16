using System.ComponentModel.DataAnnotations;

namespace PersonaKeyCore.ApiLayer.Dtos
{
    public class AppRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}