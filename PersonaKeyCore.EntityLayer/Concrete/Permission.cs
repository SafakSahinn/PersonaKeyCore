using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaKeyCore.EntityLayer.Concrete
{
    public class Permission
    {
        public int Id { get; set; }
        public int RoleId { get; set; } // Yeni Role sınıfının ID'si
        public Role Role { get; set; } // Yeni Role sınıfına navigasyon özelliği
        public int DoorId { get; set; }
        public Door Door { get; set; }
    }
}
