using System;

namespace PersonaKeyCore.ApiLayer.Dtos
{
    public class AccessLogDto
    {
        public int PersonId { get; set; }
        public int DoorId { get; set; }
        public string Status { get; set; }
    }
}