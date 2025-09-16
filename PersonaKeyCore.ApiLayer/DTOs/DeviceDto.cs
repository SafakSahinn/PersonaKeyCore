using System.ComponentModel.DataAnnotations;

namespace PersonaKeyCore.ApiLayer.Dtos
{
    public class DeviceDto
    {
        [Required]
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public int? DoorId { get; set; }
    }
}