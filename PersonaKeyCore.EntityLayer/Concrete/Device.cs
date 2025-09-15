using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class Device
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } // ESP32 için benzersiz ID veya MAC adresi
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public int? DoorId { get; set; } // Hangi kapıya bağlı olduğunu gösterir
        public Door Door { get; set; }
    }
}
